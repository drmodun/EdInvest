using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Items.Course;
using Shared.Contracts.Responses.Items.Course;
using Shared.Models.Items;

namespace API.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly BaseService<Course, CourseMapper, ItemRepo<Course, GetCourseRequest, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, CourseValidation
                > _courseService;

        public CourseController(BaseService<Course, CourseMapper, ItemRepo<Course, GetCourseRequest, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, CourseValidation
                > service)
        {
            _courseService = service;
        }
        [HttpGet(AppRoutes.Course.Get)]
        public async Task<ActionResult<GetCourseResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetCourseRequest { Id = id };
            var item = await _courseService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.Course.Create)]
        public async Task<ActionResult<CreateCourseResponse>> Post([FromBody] CreateCourseRequest request, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var item = await _courseService.Create(request, cancellationToken);
            var response = new CreateCourseResponse { Success = item != null, Course = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Course.Update)]
        public async Task<ActionResult<UpdateCourseResponse>> Update([FromBody] CreateCourseRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var updateRequest =
                new UpdateCourseRequest
                {
                    ActiveStudents = request.ActiveStudents,
                    Curriculum = request.Curriculum,
                    EndDate = request.EndDate,
                    ExpectedApplicants = request.ExpectedApplicants,
                    StartDate = request.StartDate,
                    ExpectedGraduates = request.ExpectedGraduates,
                    CategoryId = request.CategoryId,
                    CountryId = request.CountryId,
                    CurrentAmount = request.CurrentAmount,
                    Description = request.Description,
                    Goal = request.Goal,
                    Images = request.Images,
                    Id = id,
                    Name = request.Name,
                    OrganisationId = request.OrganisationId,
                    SubcategoryId = request.SubcategoryId,
                    Prices = request.Prices,
                    Tiers = request.Tiers,
                };
            var item = await _courseService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateCourseResponse { Success = item != null, Course = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpDelete(AppRoutes.Course.Delete)]
        public async Task<ActionResult<DeleteCourseResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _courseService.GetById(new GetCourseRequest { Id = id });
            if (item.OrganisationId != HttpContext.GetUserId()) { return BadRequest("Cannot delete a item that you do not own"); }
            var deletion = await _courseService.Delete(id, cancellationToken);
            var response = new DeleteCourseResponse { Success = deletion };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpGet(AppRoutes.Course.GetAll)]
        public async Task<ActionResult<GetAllCoursesResponse>> GetAll([FromQuery] GetAllCoursesRequest options)
        {
            var items = await _courseService.GetAll(options);
            return new GetAllCoursesResponse
            {
                Courses = items,
            };
        }

    }
}

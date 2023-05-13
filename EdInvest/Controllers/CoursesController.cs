using API.Routes;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Course;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Items.Course;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Responses.Items.Application;
using Domain.Validation;

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
            return await _courseService.GetById(request);
        }
        [HttpPost(AppRoutes.Course.Create)]
        public async Task<ActionResult<CreateCourseResponse>> Post([FromBody] CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var item = await _courseService.Create(request, cancellationToken);
            return new CreateCourseResponse
            {
                Success = item != null,
                Course = item,
            };
        }
        [HttpPut(AppRoutes.Course.Update)]
        public async Task<ActionResult<UpdateCourseResponse>> Update([FromBody] CreateCourseRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
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
            var item = await _courseService.Update(updateRequest, cancellationToken);
            return new UpdateCourseResponse { Success = item != null, Course = item };

        }
        [HttpDelete(AppRoutes.Course.Delete)]
        public async Task<ActionResult<DeleteCourseResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deletion = await _courseService.Delete(id, cancellationToken);
            return new DeleteCourseResponse { Success = deletion };

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

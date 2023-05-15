using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Responses.Items.OnlineCourse;
using Shared.Models.Items;

namespace API.Controllers
{
    [ApiController]
    public class OnlineCourseController : ControllerBase
    {
        private readonly BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetOnlineCourseRequest, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, OnlineCourseValidation
                > _onlineCourseService;

        public OnlineCourseController(BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetOnlineCourseRequest, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, OnlineCourseValidation
                > service)
        {
            _onlineCourseService = service;
        }
        [HttpGet(AppRoutes.OnlineCourse.Get)]
        public async Task<ActionResult<GetOnlineCourseResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetOnlineCourseRequest
            {
                Id = id,
            };
            var item = await _onlineCourseService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.OnlineCourse.Create)]
        public async Task<ActionResult<CreateOnlineCourseResponse>> Post([FromBody] CreateOnlineCourseRequest request, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var item = await _onlineCourseService.Create(request, cancellationToken);
            var response = new CreateOnlineCourseResponse { Success = item != null, OnlineCourse = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.OnlineCourse.Update)]
        public async Task<ActionResult<UpdateOnlineCourseResponse>> Update([FromBody] CreateOnlineCourseRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var updateRequest =
                new UpdateOnlineCourseRequest
                {
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
                    AvarageDuration = request.AvarageDuration,
                    ExpectedAudience = request.ExpectedAudience,
                    Lessons = request.Lessons,
                    LessonsDate = request.LessonsDate,
                    LinksToChannels = request.LinksToChannels
                };
            var item = await _onlineCourseService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateOnlineCourseResponse { Success = item != null, OnlineCourse = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpDelete(AppRoutes.OnlineCourse.Delete)]
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        public async Task<ActionResult<DeleteOnlineCourseResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _onlineCourseService.GetById(new GetOnlineCourseRequest { Id = id });
            if (item.OrganisationId != HttpContext.GetUserId()) { return BadRequest("Cannot delete a item that you do not own"); }
            var deletion = await _onlineCourseService.Delete(id, cancellationToken);
            var response = new DeleteOnlineCourseResponse { Success = deletion };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpGet(AppRoutes.OnlineCourse.GetAll)]
        public async Task<ActionResult<GetAllOnlineCoursesReponse>> GetAll([FromQuery] GetAllOnlineCoursesRequest options)
        {
            var items = await _onlineCourseService.GetAll(options);
            return new GetAllOnlineCoursesReponse
            {
                OnlineCourses = items,
            };
        }

    }
}

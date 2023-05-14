using API.Routes;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Items.OnlineCourse;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Responses.Items.Application;
using Domain.Validation;
using API.Auth;
using Microsoft.AspNetCore.Authorization;
using Shared.Constants;

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
            return await _onlineCourseService.GetById(request);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.OnlineCourse.Create)]
        public async Task<ActionResult<CreateOnlineCourseResponse>> Post([FromBody] CreateOnlineCourseRequest request, CancellationToken cancellationToken)
        {
            var item = await _onlineCourseService.Create(request, cancellationToken);
            if (request.OrganisationId != HttpContext.GetUserId())
                return BadRequest("Cannot create, update or delete an item that has a different organisation than the logged in user");
            return new CreateOnlineCourseResponse
            {
                Success = item != null,
                OnlineCourse = item,
            };
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.OnlineCourse.Update)]
        public async Task<ActionResult<UpdateOnlineCourseResponse>> Update([FromBody] CreateOnlineCourseRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (request.OrganisationId != HttpContext.GetUserId())
                return BadRequest("Cannot create, update or delete a request to create an item that has a different organisation than the logged in user");

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
            var item = await _onlineCourseService.Update(updateRequest, cancellationToken);
            return new UpdateOnlineCourseResponse { Success = item != null, OnlineCourse = item };

        }
        [HttpDelete(AppRoutes.OnlineCourse.Delete)]
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        public async Task<ActionResult<DeleteOnlineCourseResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _onlineCourseService.GetById(new GetOnlineCourseRequest { Id = id });
            if (item.OrganisationId != HttpContext.GetUserId()) { return BadRequest("Cannot delete a item that you do not own"); }
            var deletion = await _onlineCourseService.Delete(id, cancellationToken);
            return new DeleteOnlineCourseResponse { Success = deletion };

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

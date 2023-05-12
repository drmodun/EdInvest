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

namespace API.Controllers
{
    [ApiController]
    public class OnlineCourseController : ControllerBase
    {
        private readonly BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, List<OnlineCourse>
                > _onlineCourseService;

        public OnlineCourseController(BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, List<OnlineCourse>
                > service)
        {
            _onlineCourseService = service;
        }
        [HttpGet(AppRoutes.OnlineCourse.Get)]
        public async Task<ActionResult<GetOnlineCourseResponse>> Get([FromQuery] GetOnlineCourseRequest request)
        {
            return await _onlineCourseService.GetById(request.Id);
        }
        [HttpPost(AppRoutes.OnlineCourse.Create)]
        public async Task<ActionResult<CreateOnlineCourseResponse>> Post([FromBody] CreateOnlineCourseRequest request, CancellationToken cancellationToken)
        {
            var item = await _onlineCourseService.Create(request, cancellationToken);
            return new CreateOnlineCourseResponse
            {
                Success = item == null,
                OnlineCourse = item,
            };
        }
        [HttpPut(AppRoutes.OnlineCourse.Update)]
        public async Task<ActionResult<UpdateOnlineCourseResponse>> Update([FromBody] CreateOnlineCourseRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
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
                    Type = request.Type,
                    AvarageDuration = request.AvarageDuration,
                    ExpectedAudience = request.ExpectedAudience,
                    Lessons = request.Lessons,
                    LessonsDate = request.LessonsDate,
                    LinksToChannels = request.LinksToChannels
                };
            var item = await _onlineCourseService.Update(updateRequest, cancellationToken);
            return new UpdateOnlineCourseResponse { Success = item == null, OnlineCourse = item };

        }
        [HttpDelete(AppRoutes.OnlineCourse.Delete)]
        public async Task<ActionResult<DeleteOnlineCourseResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
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

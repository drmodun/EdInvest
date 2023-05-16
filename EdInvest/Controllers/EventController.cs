using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests.Items.Event;
using Shared.Contracts.Responses.Items.Event;
using Shared.Models.Items;

namespace API.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly BaseService<Event, EventMapper, ItemRepo<Event, GetEventRequest, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, EventValidation
                > _eventService;

        public EventController(BaseService<Event, EventMapper, ItemRepo<Event, GetEventRequest, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, EventValidation
                > service)
        {
            _eventService = service;
        }
        [HttpGet(AppRoutes.Event.Get)]
        public async Task<ActionResult<GetEventResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetEventRequest { Id = id };
            var item = await _eventService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPost(AppRoutes.Event.Create)]
        public async Task<ActionResult<CreateEventResponse>> Post([FromBody] CreateEventRequest request, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var item = await _eventService.Create(request, cancellationToken);
            var response = new CreateEventResponse
            {
                Success = item != null,
                Event = item,
            };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpPut(AppRoutes.Event.Update)]
        public async Task<ActionResult<UpdateEventResponse>> Update([FromBody] CreateEventRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            request.OrganisationId = (Guid)HttpContext.GetUserId();
            var updateRequest =
                new UpdateEventRequest
                {
                    Activities = request.Activities,
                    Capacity = request.Capacity,
                    Date = request.Date,
                    ExpectedAttendance = request.ExpectedAttendance,
                    Location = request.Location,
                    NotableAttendees = request.NotableAttendees,
                    NotableSpeakers = request.NotableSpeakers,
                    TicketPrice = request.TicketPrice,
                    CategoryId = request.CategoryId,
                    CountryId = request.CountryId,
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
            var item = await _eventService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateEventResponse { Success = item != null, Event = item };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpDelete(AppRoutes.Event.Delete)]
        public async Task<ActionResult<DeleteEventResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _eventService.GetById(new GetEventRequest { Id = id });
            if (item.OrganisationId != HttpContext.GetUserId()) { return BadRequest("Cannot delete a item that you do not own"); }
            var deletion = await _eventService.Delete(id, cancellationToken);
            var response = new DeleteEventResponse { Success = deletion };
            return (bool)response.Success ? Ok(response) : BadRequest(response);


        }
        [HttpGet(AppRoutes.Event.GetAll)]
        public async Task<ActionResult<GetAllEventsResponse>> GetAll([FromQuery] GetAllEventsRequest options)
        {
            var items = await _eventService.GetAll(options);
            return new GetAllEventsResponse
            {
                Events = items,
            };
        }

    }
}

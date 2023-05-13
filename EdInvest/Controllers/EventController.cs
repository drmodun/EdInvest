using API.Routes;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Event;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Items.Event;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Items.Item;

namespace API.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly BaseService<Event, EventMapper, ItemRepo<Event, GetEventRequest, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, List<Event>
                > _eventService;

        public EventController(BaseService<Event, EventMapper, ItemRepo<Event, GetEventRequest, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, List<Event>
                > service)
        {
            _eventService = service;
        }
        [HttpGet(AppRoutes.Event.Get)]
        public async Task<ActionResult<GetEventResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetEventRequest { Id = id };
            return await _eventService.GetById(request);
        }
        [HttpPost(AppRoutes.Event.Create)]
        public async Task<ActionResult<CreateEventResponse>> Post([FromBody] CreateEventRequest request, CancellationToken cancellationToken)
        {
            var item = await _eventService.Create(request, cancellationToken);
            return new CreateEventResponse
            {
                Success = item != null,
                Event = item,
            };
        }
        [HttpPut(AppRoutes.Event.Update)]
        public async Task<ActionResult<UpdateEventResponse>> Update([FromBody] CreateEventRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
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
                    TicketPrice  = request.TicketPrice,
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
            var item = await _eventService.Update(updateRequest, cancellationToken);
            return new UpdateEventResponse { Success = item != null, Event = item };

        }
        [HttpDelete(AppRoutes.Event.Delete)]
        public async Task<ActionResult<DeleteEventResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deletion = await _eventService.Delete(id, cancellationToken);
            return new DeleteEventResponse { Success = deletion };

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

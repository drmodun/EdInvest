using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Event;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Event;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class EventMapper : IMapper<Event, GetEventResponse, CreateEventRequest, UpdateEventRequest>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public EventMapper(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public Event ToEntity(CreateEventRequest request)
        {

            return new Event
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Date = request.Date,
                Location = request.Location,
                TicketPrice = request.TicketPrice,
                Capacity = request.Capacity,
                CategoryId = request.CategoryId,
                Activities = request.Activities,
                ExpectedAttendance = request.ExpectedAttendance,
                NotableAttendees = request.NotableAttendees,
                NotableSpeakers = request.NotableSpeakers,
                SubcategoryId = request.SubcategoryId,

                Goal = request.Goal,
                MainWebsite = request.MainWebsite,
                Images = request.Images,
                UpdatedAt = DateTime.UtcNow,
                Tiers = request.Tiers,
                Type = request.Type,
                Prices = request.Prices.Order().ToList(),
                OrganisationId = request.OrganisationId,

            };
        }

        public Event ToUpdatedEntity(UpdateEventRequest request)
        {
            return new Event
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Date = request.Date,
                Location = request.Location,
                TicketPrice = request.TicketPrice,
                Capacity = request.Capacity,
                CategoryId = request.CategoryId,
                Activities = request.Activities,
                ExpectedAttendance = request.ExpectedAttendance,
                NotableAttendees = request.NotableAttendees,
                NotableSpeakers = request.NotableSpeakers,
                SubcategoryId = request.SubcategoryId,

                MainWebsite = request.MainWebsite,
                Goal = request.Goal,
                Images = request.Images,
                UpdatedAt = DateTime.UtcNow,
                Tiers = request.Tiers,
                Type = request.Type,
                Prices = request.Prices.Order().ToList(),
                OrganisationId = request.OrganisationId,
            };
        }
        public GetEventResponse ToDTO(Event entity)
        {
            return new GetEventResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Date = entity.Date,
                Location = entity.Location,
                TicketPrice = entity.TicketPrice,
                Capacity = entity.Capacity,
                OrganisationName = entity.Organisation.Name,
                CategoryId = entity.CategoryId,
                Activities = entity.Activities,
                MainWebsite = entity.MainWebsite,
                ExpectedAttendance = entity.ExpectedAttendance,
                NotableAttendees = entity.NotableAttendees,
                NotableSpeakers = entity.NotableSpeakers,
                SubcategoryId = entity.SubcategoryId,

                Goal = entity.Goal,
                Images = entity.Images,
                UpdatedAt = entity.UpdatedAt,
                Tiers = entity.Tiers,
                Type = entity.Type,
                Prices = entity.Prices,
                OrganisationId = entity.OrganisationId,
                CurrentAmount = entity.Investments.Sum(x => x.Amount),
                NumberOfDonations = entity.Investments.Count,

            };
        }
    }
}

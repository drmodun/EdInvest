using Shared.Contracts.Requests.Items.Event;
using Shared.Contracts.Responses.Items.Event;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class EventMapper : IMapper<Event, GetEventResponse, CreateEventRequest, UpdateEventRequest>
    {
        private readonly InvestmentMapper _investmentMapper;

        public EventMapper(InvestmentMapper investmentMapper)
        {
            _investmentMapper = investmentMapper;
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
                CurrentAmount = request.CurrentAmount,
                SubcategoryId = request.SubcategoryId,
                CountryId = request.CountryId,
                Goal = request.Goal,
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
                CurrentAmount = request.CurrentAmount,
                SubcategoryId = request.SubcategoryId,
                CountryId = request.CountryId,
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
                CategoryId = entity.CategoryId,
                Activities = entity.Activities,

                ExpectedAttendance = entity.ExpectedAttendance,
                NotableAttendees = entity.NotableAttendees,
                NotableSpeakers = entity.NotableSpeakers,
                CurrentAmount = entity.CurrentAmount,
                Investments = entity.Investments.Select(_investmentMapper.ToDTO).ToList(),
                SubcategoryId = entity.SubcategoryId,
                CountryId = entity.CountryId,
                Goal = entity.Goal,
                Images = entity.Images,
                UpdatedAt = entity.UpdatedAt,
                Tiers = entity.Tiers,
                Type = entity.Type,
                Prices = entity.Prices,
                OrganisationId = entity.OrganisationId,

            };
        }




    }
}

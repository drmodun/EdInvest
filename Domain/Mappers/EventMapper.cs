using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Event;
using Domain.Contracts.Responses.Items.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class EventMapper
    {
        public static Event ToEntity(CreateEventRequest request)
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
                CreatedAt = DateTime.UtcNow,
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
                Prices = request.Prices,
                OrganisationId = request.OrganisationId,
            };
        }

        public static Event ToUpdatedEntity(UpdateEventRequest request)
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
                CreatedAt = DateTime.UtcNow,
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
                Prices = request.Prices,
                OrganisationId = request.OrganisationId,
            };
        }
        public static GetEventResponse ToDTO(Event entity)
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
                CreatedAt = entity.CreatedAt,
                ExpectedAttendance = entity.ExpectedAttendance,
                NotableAttendees = entity.NotableAttendees,
                NotableSpeakers = entity.NotableSpeakers,
                CurrentAmount = entity.CurrentAmount,
                Investments = entity.Investments.Select(InvestmentMapper.ToDTO).ToList(),
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

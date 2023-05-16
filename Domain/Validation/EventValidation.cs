﻿using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class EventValidation : ItemValidation<Event>
    {
        public EventValidation(CategoryRepo categoryRepo, SubcategoryRepo subcategoryRepo, ICountryRepo countryRepo,
            UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> organisationRepo) :
            base(categoryRepo, subcategoryRepo, countryRepo, organisationRepo)
        {
            RuleFor(x => x.Activities).NotEmpty().WithMessage("Activities cannot be empty");
            RuleFor(x => x.TicketPrice).Must(x => x >= 0 && x < 10000).WithMessage("Tickets cost between 0 and 10000 euros/dollars");
            RuleFor(x => x.NotableSpeakers).NotEmpty().WithMessage("Speakers cannot be empty");
            RuleFor(x => x.NotableAttendees).NotEmpty().WithMessage("Attendees cannot be empty");
            RuleFor(x => new { x.Capacity, x.ExpectedAttendance }).Must(x => x.ExpectedAttendance > 0 && x.ExpectedAttendance <= x.Capacity).WithMessage("Tickets cost between 0 and 10000 euros/dollars");
            RuleFor(x => x.Capacity).Must(x => x > 0 && x < 100000).WithMessage("Capacity is valid between 0 and 100000");

        }
    }
}

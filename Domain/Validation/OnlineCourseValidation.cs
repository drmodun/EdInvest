using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Models.Items;
using Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    public class OnlineCourseValidation : ItemValidation<OnlineCourse>
    {
        public OnlineCourseValidation(CategoryRepo categoryRepo, SubcategoryRepo subcategoryRepo, ICountryRepo countryRepo,
            UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> organisationRepo) :
            base(categoryRepo, subcategoryRepo, countryRepo, organisationRepo)
        {
            RuleFor(x => x.AvarageDuration).Must(x => x > 1 && x < 600).WithMessage("Avarage duration must be between 1 minute and 10 hours");
            RuleFor(x => x.ExpectedAudience).Must(x => x > 0).WithMessage("Expected Audience must be positive");
            RuleFor(x => x.Lessons).NotEmpty().WithMessage("Lessons must not be empty");
            RuleFor(x => x.LinksToChannels).NotEmpty().WithMessage("Link to channels must not be empty");
            RuleFor(x => new { x.LessonsDate, x.Lessons }).Must(x => x.Lessons.Count != x.LessonsDate.Count).WithMessage("Lessons must have dates");
        }
    }
};

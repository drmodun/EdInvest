using FluentValidation;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class OrganisationValidation : UserValidation<Organisation>
    {
        public OrganisationValidation() : base()
        {
            RuleFor(x => x.NumberOfMembers).Must(n => n > 0 && n < 1000000).WithMessage("Must be bewteen 1 and a million members");
        }
    }
}

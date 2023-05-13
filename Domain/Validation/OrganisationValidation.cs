using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    public class OrganisationValidation : UserValidation<Organisation>
    {
        public OrganisationValidation(ICountryRepo countryRepo) : base(countryRepo)
        {
            RuleFor(x => x.NumberOfMembers).Must(n => n > 0 && n < 1000000).WithMessage("Must be bewteen 1 and a million members");
        }
    }
}

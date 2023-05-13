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
    public class InvestorValidation : UserValidation<Investor>
    {
        public InvestorValidation(ICountryRepo countryRepo) : base(countryRepo)
        {
            RuleFor(x => x.NumberOfEmployees).Must(n => n > 0 && n < 10000000).WithMessage("Must be bewteen 1 and 10 million employees");

        }
    }
}

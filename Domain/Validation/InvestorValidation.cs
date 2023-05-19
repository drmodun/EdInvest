using FluentValidation;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class InvestorValidation : UserValidation<Investor>
    {
        public InvestorValidation() : base()
        {
            RuleFor(x => x.NumberOfEmployees).Must(n => n > 0 && n < 10000000).WithMessage("Must be bewteen 1 and 10 million employees");

        }
    }
}

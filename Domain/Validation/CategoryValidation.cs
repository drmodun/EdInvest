using FluentValidation;
using Shared.Models;

namespace Domain.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name cannot be longer than 50 characters");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot be longer than 50 characters");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name cannot be shorter than 3 characters");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Decription cannot be shorter than 3 characters");

        }
    }
}

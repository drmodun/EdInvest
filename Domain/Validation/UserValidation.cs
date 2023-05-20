using FluentValidation;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class UserValidation<TUser> : AbstractValidator<TUser> where TUser : User
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must be less than 500 characters");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Descriptio must be at least 20 characters long");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.WalletAddress).MaximumLength(35).WithMessage("Wallet address must be less than 35 characters");
            RuleFor(x => x.WalletAddress).MinimumLength(26).WithMessage("Wallet address must be at least 26 characters");
            RuleFor(x => x.WalletAddress).Matches("^[a-zA-Z0-9]*$").WithMessage("Wallet address must be alphanumeric");
            RuleFor(x => x.UpdatedAt).Must(d => d < DateTime.Now).WithMessage("Invalid date");



        }
    }
}


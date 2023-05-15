using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class UserValidation<TUser> : AbstractValidator<TUser> where TUser : User
    {
        private readonly ICountryRepo _countryRepo;
        public UserValidation(ICountryRepo countryRepo)
        {
            //change password check later
            _countryRepo = countryRepo;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must be less than 500 characters");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Descriptio must be at least 20 characters long");
            RuleFor(x => x.CountryId).MustAsync(async (n, cancellationToken) => { return await _countryRepo.GetById(n) != null; }).WithMessage("Country is not valid");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Password must be at least 8 characters");
            RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter");
            RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter");
            RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Password must contain at least one number");
            RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country is required");
            RuleFor(x => x.Balance).Must(b => b > 0).WithMessage("Balance must be a positive number");
            RuleFor(x => x.WalletAddress).MaximumLength(35).WithMessage("Wallet address must be less than 35 characters");
            RuleFor(x => x.WalletAddress).MinimumLength(26).WithMessage("Wallet address must be at least 26 characters");
            RuleFor(x => x.WalletAddress).Matches("^[a-zA-Z0-9]*$").WithMessage("Wallet address must be alphanumeric");
            RuleFor(x => x.CreatedAt).Must(d => d < DateTime.Now).WithMessage("Invalid date");
            RuleFor(x => new { x.UpdatedAt, x.CreatedAt }).Must(d => d.UpdatedAt < DateTime.Now && d.CreatedAt <= d.UpdatedAt).WithMessage("Update cannot happen prior to creation");



        }
    }
}


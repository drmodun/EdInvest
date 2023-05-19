using Domain.Repositories.Implementations;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class InvestmentsValidation : AbstractValidator<Investments>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;
        private readonly UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> _userRepo;

        public InvestmentsValidation(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo,
            UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> userRepo)
        {
            _itemRepo = itemRepo;
            _userRepo = userRepo;
            RuleFor(x => x.InvestorId).MustAsync(async (n, cancellationToken) =>
            { return await _userRepo.GetById(new GetInvestorRequest { Id = n }) != null; }).WithMessage("Investor is not valid");
            RuleFor(x => x.ItemId).MustAsync(async (n, cancellationToken) =>
            { return await _itemRepo.GetById(new GetItemRequest { Id = n }) != null; }).WithMessage("Item is not valid");
            RuleFor(x => x.Tier).Must(x => x >= 0 && x < 11).WithMessage("Tier mustz be betwen 0 and 10");
            RuleFor(x => x.Amount).Must(x => x > 0).WithMessage("Amount must be more than 0");

        }
    }
}

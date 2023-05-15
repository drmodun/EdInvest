using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Category;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Subcategory;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class ItemValidation<TItem> : AbstractValidator<TItem> where TItem : Item
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly SubcategoryRepo _subCategoryRepo;
        private readonly ICountryRepo _countryRepo;
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;
        private readonly UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> _organisatorRepo;
        //remmber to reesaearch if requests are problematic in repos
        public ItemValidation(CategoryRepo categoryRepo, SubcategoryRepo subcategoryRepo, ICountryRepo countryRepo,
            UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> organisationRepo,
            ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subcategoryRepo;
            _countryRepo = countryRepo;
            _itemRepo = itemRepo;
            _organisatorRepo = organisationRepo;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Description).MaximumLength(10000).WithMessage("Description must be less than 1000 characters");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Description must be at least 20 characters long");
            RuleFor(x => x.CountryId).MustAsync(async (n, cancellationToken) =>
            { return await _countryRepo.GetById(n) != null; }).WithMessage("Country is not valid");
            RuleFor(x => x.Images).NotEmpty().WithMessage("Images cannot be empty");
            RuleFor(x => x.Goal).Must(g => g > 0).WithMessage("Goal must be positive");
            RuleFor(x => new { x.CurrentAmount, x.Goal }).Must(c => c.CurrentAmount >= 0 && c.CurrentAmount <= c.Goal).WithMessage("Current amount must be positive and smaller than the goal");
            RuleFor(x => x.CategoryId).MustAsync(async (n, cancellationToken) =>
            { return await _categoryRepo.GetById(new GetCategoryRequest { Id = n }) != null; }).WithMessage("Category is not valid");
            RuleFor(x => x.SubcategoryId).MustAsync(async (n, cancellationToken) =>
            { return await _subCategoryRepo.GetById(new GetSubcategoryRequest { Id = n }) != null; }).WithMessage("Subcategory is not valid");
            RuleFor(x => x.OrganisationId).MustAsync(async (n, cancellationToken) =>
            { return await _organisatorRepo.GetById(new GetOrganisationRequest { Id = n }) != null; }).WithMessage("Organisation is not valid");
            RuleFor(x => x.UpdatedAt).Must(d => d < DateTime.Now).WithMessage("Invalid date");
            RuleFor(x => x.Tiers).NotEmpty().WithMessage("Tiers must exist");
            RuleFor(x => x.Prices).NotEmpty().WithMessage("Prices must be set");
            RuleFor(x => new { x.Id, x.OrganisationId }).MustAsync(async (n, cancellationToken) =>
            {
                var item = await _itemRepo.GetById(new GetItemRequest { Id = n.Id });
                if (item == null)
                    return true;
                return item.OrganisationId == n.OrganisationId;
            }).
            WithMessage("Organisation cannot be changed");



        }
    }
}

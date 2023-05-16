using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using FluentValidation;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Validation
{
    public class ApplicationValidation : ItemValidation<Application>
    {
        public ApplicationValidation(CategoryRepo categoryRepo, SubcategoryRepo subcategoryRepo, ICountryRepo countryRepo,
            UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest> organisationRepo,
            ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo) :
            base(categoryRepo, subcategoryRepo, countryRepo, organisationRepo, itemRepo)
        {

            RuleFor(x => x.EstimatedRelease).Must(x => x > DateTime.Now).WithMessage("Application release date must be in the future");
            RuleFor(x => x.EstimatedNumberOfUsers).Must(x => x > 0).WithMessage("Appliaction must have a set number of users");
            RuleFor(x => x.AppPurpose).NotEmpty().WithMessage("Application must have a purpose (at least somebody does)");
            RuleFor(x => x.Markets).NotEmpty().WithMessage("Application must be availablke on markets");
            RuleFor(x => x.Features).NotEmpty().WithMessage("Application must have features");
        }
    }
}

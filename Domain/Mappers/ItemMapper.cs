using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class ItemMapper : IMapper<Item, GetItemResponse, CreateItemRequest, UpdateItemRequest>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public ItemMapper(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public GetItemResponse ToDTO(Item entity)
        {
            return new GetItemResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                CountryId = entity.CountryId,
                Images = entity.Images,
                NumberOfDonations = entity.Investments.Count,
                Goal = entity.Goal,
                OrganisationId = entity.OrganisationId,
                Prices = entity.Prices,
                SubcategoryId = entity.SubcategoryId,
                Tiers = entity.Tiers,
                Type = entity.Type,
                OrganisationName = entity.Organisation.Name,
                CurrentAmount = _itemRepo.GetCurrentAmount(entity.Id),
                UpdatedAt = entity.UpdatedAt,
                MainWebsite = entity.MainWebsite,
            };
        }
        public Item ToEntity(CreateItemRequest request)
        {
            throw new NotImplementedException();
        }
        public Item ToUpdatedEntity(UpdateItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

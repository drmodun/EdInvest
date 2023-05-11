using Shared.Models.Items;
using Shared.Enums;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using Shared.Contracts.Responses.Items.OnlineCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class ItemMapper : IMapper<Item, GetItemResponse, CreateItemRequest,  UpdateItemRequest>
    {
        private readonly InvestmentMapper _investmentMapper;

        public ItemMapper(InvestmentMapper mapper)
        {
            _investmentMapper = mapper;
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
                CurrentAmount = entity.CurrentAmount,
                Images = entity.Images,
                Goal = entity.Goal,
                Investments = entity.Investments.Select(_investmentMapper.ToDTO).ToList(),
                OrganisationId = entity.OrganisationId,
                Prices = entity.Prices,
                SubcategoryId = entity.SubcategoryId,
                Tiers = entity.Tiers,
                Type = entity.Type,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
        public Item ToEntity(CreateItemRequest request)
        {
            throw new NotImplementedException();
        }
        public Item ToUpdatedEntity(UpdateItemRequest    request)
        {
            throw new NotImplementedException();
        }
        //these will most likely never get called, but I will implement them for the sake of the interface (tere will never be create or update Item enpoints)
    }
}

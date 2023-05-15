using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Investments;
using Shared.Models;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class InvestmentMapper : IMapper<Investments, GetInvestmentResponse, CreateInvestmentRequest, UpdateInvestmentRequest>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public InvestmentMapper(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public GetInvestmentResponse ToDTO(Investments entity)
        {
            return new GetInvestmentResponse
            {
                
                InvestorId = entity.InvestorId,
                ItemId = entity.ItemId,
                UpdatedAt = entity.UpdatedAt,
                Tier = entity.Tier,
                Amount = entity.Amount

            };
        }
        public Investments? ToUpdatedEntity(UpdateInvestmentRequest request)
        {
            var investment = CreateUpdatedInvestment(request);
            return investment.Result;
        }
        public Investments? ToEntity(CreateInvestmentRequest request)
        {
            var investment = CreateInvestment(request);
            return investment.Result;
            
        }
        public async Task<Investments?> CreateInvestment(CreateInvestmentRequest request)
        {
            var item = await _itemRepo.GetById(new GetItemRequest { Id = request.ItemId });
            if (item == null)
                return null;
            var tier = 0;
            foreach (decimal price in item.Prices)
            {
                if (price < request.Amount)
                    tier++;
            }
            if (tier == 0)
                return null;
            return new Investments
            {
                Tier = tier,
                
                InvestorId = (Guid)request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = DateTime.UtcNow,
                Amount = request.Amount,
            };
        }
        public async Task<Investments?> CreateUpdatedInvestment(UpdateInvestmentRequest request)
        {
            var item = await _itemRepo.GetById(new GetItemRequest { Id = request.ItemId });
            if (item == null)
                return null;
            var tier = 0;
            foreach (decimal price in item.Prices)
            {
                if (price < request.Amount)
                    tier++;
            }
            if (tier == 0)
                return null;
            return new Investments
            {
                Tier = tier,
                
                InvestorId = (Guid)request.InvestorId,
                ItemId = request.ItemId,
                UpdatedAt = DateTime.UtcNow,
                Amount = request.Amount,
            };
    }
    }
}

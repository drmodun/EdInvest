using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Investments;
using Shared.Contracts.Responses.Ranked;
using Shared.Models;
using Shared.Models.Items;

namespace Domain.Mappers
{
    public class InvestmentMapper : IMapper<Investments, RankedInvestmentResponse, CreateInvestmentRequest, UpdateInvestmentRequest>
    {
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public InvestmentMapper(ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public RankedInvestmentResponse ToDTO(Investments entity)
        {
            return new RankedInvestmentResponse
            {
                Amount = entity.Amount,
                InvestorId = entity.InvestorId,
                InvestorName = entity.Investor.Name,
                ItemId = entity.ItemId,
                ItemName = entity.Item.Name,
                OrganisationId = entity.Item.OrganisationId,
                OrganisationName = entity.Item.Organisation.Name,
                Tier = entity.Tier,
                InvestorImage = entity.Investor.ProfilePicture,
                ItemImage = entity.Item.Images[0],
                UpdatedAt = entity.UpdatedAt
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

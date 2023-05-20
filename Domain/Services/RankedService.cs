using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses;
using Shared.Contracts.Responses.Ranked;
using Shared.Contracts.Responses.RankedInvestor;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Domain.Services
{
    public class RankedService
    {
        private readonly UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> _userRepo;
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;
        private readonly InvestmentRepo _investmentRepo;
        public RankedService(UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> userRepo,
            ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo,
            InvestmentRepo investmentRepo)
        {
            _userRepo = userRepo;
            _itemRepo = itemRepo;
            _investmentRepo = investmentRepo;

        }

        public async Task<List<RankedItemResponse>> GetMyInvestedItems(Guid userId)
        {
            return await _itemRepo.GetAllInvestedItems(userId);
        }

        public async Task<List<RankedItemResponse>> GetItemsForInvestor(Guid id)
        {
            return await _itemRepo.GetAllInvestedItems(id);
        }
        public async Task<List<RankedResponse>> GetInvestors(Guid courseId)
        {
            return await _userRepo.GetInvestors(courseId);
        }
        public async Task<List<RankedResponse>> GetTopInvestors()
        {

            return await _userRepo.GetTopGlobalInvestors();
        }
        public async Task<List<RankedInvestmentResponse>> GetInvestmentsForOrganisation(Guid id)
        {
            return await _investmentRepo.GetInvestmentsForOrganisaton(id);
        }
        public async Task<StatsResponse> GetStats()
        {
            return await _investmentRepo.GetStats();
        }



    }
}

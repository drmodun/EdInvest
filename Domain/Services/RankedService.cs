using Domain.Repositories.Implementations;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses.Ranked;
using Shared.Contracts.Responses.RankedInvestor;
using Shared.Models.Items;
using Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RankedService
    {
        private readonly UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> _userRepo;
        private readonly ItemRepo<Item, GetItemRequest, GetAllItemsRequest> _itemRepo;

        public RankedService(UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest> userRepo,
            ItemRepo<Item, GetItemRequest, GetAllItemsRequest> itemRepo)
        {
            _userRepo = userRepo;
            _itemRepo = itemRepo;
        }

        public async Task<List<RankedItemResponse>> GetAllItems(Guid userId)
        {
            return await _itemRepo.GetAllInvestments(userId);
        }
        public async Task<List<RankedResponse>> GetInvestors(Guid courseId)
        {
            return await _userRepo.GetInvestors(courseId);
        }
        public async Task<List<RankedResponse>> GetTopInvestors() {
        
            return await _userRepo.GetTopGlobalInvestors();
        }



    }
}

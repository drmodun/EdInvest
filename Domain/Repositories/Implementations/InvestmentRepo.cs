using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses;
using Shared.Contracts.Responses.RankedInvestor;
using Shared.Models;

namespace Domain.Repositories.Implementations
{
    public class InvestmentRepo : IReadRepo<Investments, GetInvestmentRequest, GetAllInvestmentsRequest>, IInvestmentsRepo
    {
        private readonly EdInvestContext _context;

        public InvestmentRepo(EdInvestContext context)
        {
            _context = context;
        }


        public async Task<Investments?> GetById(GetInvestmentRequest request)
        {
            return await _context.Investments
                .FirstOrDefaultAsync(i => i.InvestorId == request.InvestorId && i.ItemId == request.itemId);
        }

        public async Task<List<Investments>> GetAll(GetAllInvestmentsRequest options)
        {
            return await _context.Investments
                .Where(i => i.ItemId == options.ItemId || options.ItemId == null)
                .Where(i => i.InvestorId == options.InvestorId || options.InvestorId == null)
                .Where(i => i.Tier == options.Tier || options.Tier == null)
                .Where(i => i.UpdatedAt > options.UpdatedAt || options.Tier == null)
                .ToListAsync();
        }

        public async Task<List<RankedResponse>> GetInvestmentsForOrganisaton(Guid organisatinId)
        {
            return await _context.Investments
                .Include(i => i.Item)
                .Include(i => i.Investor)
                .Where(i => i.Item.OrganisationId == organisatinId)
                .Select(i => new RankedResponse
                {
                    Amount = i.Amount,
                    InvestorId = i.InvestorId,
                    Email = i.Investor.Email,
                    Image = i.Investor.ProfilePicture,
                    Name = i.Item.Name,
                })
                .ToListAsync();
        }
        public async Task<StatsResponse> GetStats()
        {
            var result = await _context.Investments
                .ToListAsync();
            var stats = new StatsResponse
            {
                NumberOfInvestments = result.Count(),
                TotalMoneyDonated = result.Sum(i => i.Amount),
                NumberOfInvestors = result.DistinctBy(i => i.InvestorId).Count(),
                NumberOfProjects = result.DistinctBy(i => i.ItemId).Count(),
            };
            return stats;
        }
        public async Task<decimal> GetSpent(Guid investorId)
        {
            return await _context.Investments
                .Where(i => i.InvestorId == investorId)
                .SumAsync(i => i.Amount);
        }
        public async Task<decimal> GetEarned(Guid organisationId)
        {
            return await _context.Investments
                .Include(i => i.Item)
                .Where(i => i.Item.OrganisationId == organisationId)
                .SumAsync(i => i.Amount);
        }

    }
}

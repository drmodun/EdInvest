using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Requests.Investments;
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
    }
}

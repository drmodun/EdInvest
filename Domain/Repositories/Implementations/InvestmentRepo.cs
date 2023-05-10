using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Investments;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Responses.Items.Item;
using Domain.Helpers;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class InvestmentRepo : IReadRepo<Investments, N_NKey, GetAllInvestmentsRequest, List<Investments>>,IInvestmentsRepo 
    {
        private readonly EdInvestContext _context;

        public InvestmentRepo(EdInvestContext context)
        {
            _context = context;
        }


       public async Task<Investments?> GetById(N_NKey id)
        {
            return await _context.Investments
                .FirstOrDefaultAsync(i => i.InvestorId == id.investorId && i.ItemId == id.itemId);
        }

        public async Task<List<Investments>> GetAll(GetAllInvestmentsRequest options)
        {
            return await _context.Investments
                .Where(i=>i.ItemId == options.ItemId)
                .Where(i=>i.InvestorId == options.InvestorId)
                .Where(i=>options.Tier == options.Tier)
                .Where(i=>i.CreatedAt > options.CreatedAt)
                .ToListAsync();
        }
    }
}

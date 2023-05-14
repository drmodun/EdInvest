using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Domain.Repositories.Implementations
{
    public class CountryRepo : ICountryRepo
    {
        private readonly EdInvestContext _context;
        public CountryRepo(EdInvestContext context)
        {
            _context = context;
        }
        public async Task<Country?> GetById(Guid id)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}

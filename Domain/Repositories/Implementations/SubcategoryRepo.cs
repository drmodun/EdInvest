using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Requests.Subcategory;
using Shared.Models;

namespace Domain.Repositories.Implementations
{
    public class SubcategoryRepo : IReadRepo<Subcategory, GetSubcategoryRequest, GetAllSubcategoriesRequest>, ISubcategoryRepo
    {
        private readonly EdInvestContext _context;

        public SubcategoryRepo(EdInvestContext context)
        {
            _context = context;
        }
        public async Task<Subcategory?> GetById(GetSubcategoryRequest request)
        {
            return await _context.Subcategories.FindAsync(request.Id);
        }
        public async Task<List<Subcategory>> GetAll(GetAllSubcategoriesRequest options)
        {
            return await _context.Subcategories
                .Where(sc => sc.Name == options.Name
                || options.Name == null)
                .Where(sc => sc.CategoryId == options.CategoryId
                || options.CategoryId == null
                ).ToListAsync();
        }



    }


}


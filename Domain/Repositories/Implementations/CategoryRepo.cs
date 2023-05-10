using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Category;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Responses.Items.Item;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class CategoryRepo : IReadRepo<Category, Guid, GetAllCategoriesRequest>, ICategoryRepo
    {
        private readonly EdInvestContext _context;

        public CategoryRepo(EdInvestContext context)
        {
            _context = context;
        }

        public async Task<Category> GetById(Guid id)
        {
            return _context.Categories.Include(c => c.Subcategories).First(c => c.Id == id);
        }
        public async Task<List<Category>>GetAll(GetAllCategoriesRequest options) {
            return await _context.Categories.Include(c=>c.Subcategories).Where(c => c.Name.Contains(options.Name) || options.Name == null).ToListAsync();
        }
    }
}

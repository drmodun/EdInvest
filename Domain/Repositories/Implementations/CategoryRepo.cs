using Data.Entities;
using Shared.Models;
using Shared.Models.Items;
using Shared.Contracts.Requests.Category;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class CategoryRepo : IReadRepo<Category, GetCategoryRequest, GetAllCategoriesRequest>, ICategoryRepo
    {
        private readonly EdInvestContext _context;

        public CategoryRepo(EdInvestContext context)
        {
            _context = context;
        }

        public async Task<Category> GetById(GetCategoryRequest request)
        {
            return _context.Categories.Include(c => c.Subcategories).First(c => c.Id == request.Id);
        }
        public async Task<List<Category>>GetAll(GetAllCategoriesRequest options) {
            return await _context.Categories.Include(c=>c.Subcategories).Where(c => c.Name.Contains(options.Name) || options.Name == null).ToListAsync();
        }
    }
}

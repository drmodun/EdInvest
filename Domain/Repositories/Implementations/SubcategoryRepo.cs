using Data.Entities;
using Shared.Models;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Subcategory;
using Shared.Contracts.Responses.Items.Item;
using Shared.Contracts.Responses.Subcategory;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(sc => sc.CatgoryId == options.CategoryId
                || options.CategoryId == null
                ).ToListAsync();
        }
               

           
                }


    }


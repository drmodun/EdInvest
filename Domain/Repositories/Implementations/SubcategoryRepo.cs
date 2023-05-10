using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Requests.Subcategory;
using Domain.Contracts.Responses.Items.Item;
using Domain.Contracts.Responses.Subcategory;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class SubcategoryRepo : IReadRepo<Subcategory, Guid, GetAllSubcategoriesRequest, List<Subcategory>>, ISubcategoryRepo
    {
        private readonly EdInvestContext _context;

        public SubcategoryRepo(EdInvestContext context)
        {
            _context = context;
        }
        public async Task<Subcategory?> GetById(Guid id)
        {
            return await _context.Subcategories.FindAsync(id);
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


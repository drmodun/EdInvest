﻿using Data.Entities;
using Shared.Models;
using Shared.Models.Items;
using Shared.Enums;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using Domain.Mappers;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Contracts.Items.Item;

namespace Domain.Repositories.Implementations 
{
    public class ItemRepo<TEntity, TGet, TOptions> : 
        IReadRepo<TEntity, TGet, TOptions>, IItemRepo<TEntity, TGet, TOptions> 
        where TEntity : Item where TOptions : GetAllItemsRequest
        where TGet : GetItemRequest
    {
        private readonly EdInvestContext _context;

        public ItemRepo(EdInvestContext edInvest){
            _context = edInvest;
            
        }
        

        public async Task<TEntity?> GetById(TGet request)
        {
            var item = await _context.Items
                .OfType<TEntity>()
                .Include(x => x.Investments)
                .FirstOrDefaultAsync(x=>x.Id==request.Id);
            return item;
        }
        public async Task<List<TEntity>> GetAll(TOptions options)
        {
            var list = await _context.Items
                .Include(x => x.Investments)
                .OfType<TEntity>()
                .Where(x => x.Name.Contains(options.Name) || options.Name == null)
                .Where(x => x.CategoryId == options.CategoryId || options.CategoryId == null)
                .Where(x => x.SubcategoryId == options.SubcategoryId || options.SubcategoryId == null)
                .Where(x => x.OrganisationId == options.OrganisationId || options.OrganisationId == null)
                .ToListAsync();
            return list;

        }
    }
}

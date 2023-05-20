using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Ranked;
using Shared.Models.Items;

namespace Domain.Repositories.Implementations
{
    public class ItemRepo<TEntity, TGet, TOptions> :
        IReadRepo<TEntity, TGet, TOptions>, IItemRepo<TEntity, TGet, TOptions>
        where TEntity : Item where TOptions : GetAllItemsRequest
        where TGet : GetItemRequest
    {
        private readonly EdInvestContext _context;

        public ItemRepo(EdInvestContext edInvest)
        {
            _context = edInvest;

        }


        public async Task<TEntity?> GetById(TGet request)
        {
            var item = await _context.Items
                .OfType<TEntity>()
                .Include(x => x.Organisation)
                .Include(x => x.Investments)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            return item;
        }
        public async Task<List<TEntity>> GetAll(TOptions options)
        {
            var list = await _context.Items
                .Include(x => x.Investments)
                .Include(x => x.Organisation)
                .OfType<TEntity>()
                .Where(x => x.Name.Contains(options.Name) || options.Name == null)
                .Where(x => x.CategoryId == options.CategoryId || options.CategoryId == null)
                .Where(x => x.SubcategoryId == options.SubcategoryId || options.SubcategoryId == null)
                .Where(x => x.OrganisationId == options.OrganisationId || options.OrganisationId == null)
                .ToListAsync();
            return list;

        }
        public async Task<List<RankedItemResponse>> GetAllInvestedItems(Guid userId)
        {
            return await _context.Investments
                .Where(i => i.InvestorId == userId)
                .Include(i => i.Item)

                .Select(i => new RankedItemResponse
                {
                    Id = i.ItemId,
                    Amount = i.Amount,
                    Image = i.Item.Images[0],
                    Tier = i.Tier,
                    Name = i.Item.Name,
                    OrganisationId = i.Item.OrganisationId,
                    CurrentAmount = i.Item.Investments.Sum(x => x.Amount),
                    Goal = i.Item.Goal,
                    OrganisationName = i.Item.Organisation.Name,
                    ItemDescription = i.Item.Description,
                    Type = i.Item.Type,
                    Updated = i.UpdatedAt
                })
                .ToListAsync();


        }
        public decimal GetCurrentAmount(Guid itemId)
        {
            var amount =
                _context.Investments
               .Where(i => i.ItemId == itemId)
               .Sum(i => i.Amount);
            if (amount == null)
                return 0;
            return amount;



        }
    }
}

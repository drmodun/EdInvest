using Data.Entities;
using Domain.Helpers;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Domain.Repositories.Implementations
{
    public class WriteRepo<TEntity, TId> : IWriteRepo<TEntity, TId> where TEntity : class
        where TId : struct
    {
        private readonly EdInvestContext _context;
        private readonly DbSet<TEntity> _set;
        public WriteRepo(EdInvestContext edInvestContext)
        {
            _context = edInvestContext;
            _set = _context.Set<TEntity>();
        }
        public async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _set.AddAsync(entity, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken) > 0;

        }
        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken, TId id)
        {

            TEntity? oldEntity = null;
            if (id is Guid)
                oldEntity = await _set.FindAsync(id, cancellationToken);
            else if (id is N_NKey)
            {
                N_NKey? n_nId = id as N_NKey?;
                if (n_nId.HasValue) { oldEntity = await _set.FindAsync(n_nId.Value.investorId, n_nId.Value.itemId, cancellationToken); }
            }
            if (oldEntity == null)
                return false;
            _set.Remove(oldEntity);
            await _set.AddAsync(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;

        }
        public async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            TEntity? entity = null;
            if (id is Guid)
                entity = await _set.FindAsync(id, cancellationToken);
            else if (id is N_NKey)
            {
                N_NKey? n_nId = id as N_NKey?;
                if (n_nId.HasValue) {  entity = await _set.FindAsync(n_nId.Value.investorId, n_nId.Value.itemId, cancellationToken);}
            }
            if (entity == null)
                return false;
            _set.Remove(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}

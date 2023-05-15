using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations
{
    public class WriteRepo<TEntity, TId> : IWriteRepo<TEntity, TId> where TEntity : class
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
            await _set.AddAsync(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;

        }
        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _set.Update(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;

        }
        public async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await _set.FindAsync(id, cancellationToken);
            _set.Remove(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}

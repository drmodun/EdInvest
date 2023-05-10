using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IWriteRepo<TEntity, TId>
    {
        public Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
      public  Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);

    }
}

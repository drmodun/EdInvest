using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IReadRepo<TEntity, TId, TOptions>
    {
        public Task<TEntity?> GetById(TId id);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}

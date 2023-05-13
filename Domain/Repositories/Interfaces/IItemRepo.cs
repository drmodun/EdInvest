using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Contracts.Items.Item;

namespace Domain.Repositories.Interfaces
{
    public interface IItemRepo<TEntity, TGet, TOptions>
    {
        public Task<TEntity?> GetById(TGet request);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}

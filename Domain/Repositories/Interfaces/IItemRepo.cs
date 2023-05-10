using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IItemRepo<TEntity, TOptions>
    {
        public Task<TEntity?> GetById(Guid id);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}

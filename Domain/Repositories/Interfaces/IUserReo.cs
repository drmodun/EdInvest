using Data.Entities.Models.Users;
using Domain.Contracts.Requests.Users.User;
using Domain.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepo<TEntity, TOptions>
    {
        public Task<TEntity?> GetById(Guid id);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}

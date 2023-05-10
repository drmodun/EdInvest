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
    public interface IUserRepo
    {
        public Task<User?> GetById(Guid id);
        public Task<GetAllUsersResponse> GetAll(GetAllUsersRequest options);
    }
}

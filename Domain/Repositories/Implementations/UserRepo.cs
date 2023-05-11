using Data.Entities;
using Shared.Models.Items;
using Shared.Models.Users;
using Shared.Enums;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Items.Item;
using Shared.Contracts.Responses.Users.User;
using Domain.Mappers;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class UserRepo<TEntity, TOptions> 
        : IReadRepo<TEntity, Guid, TOptions>, IUserRepo<TEntity, TOptions> 
        where TEntity : User where TOptions : GetAllUsersRequest
    {
        private readonly EdInvestContext _context;
        //private readonly _applicationMapper;

        public UserRepo(EdInvestContext edInvest
            )//, CourseMapper courseMapper) { 
        {
            _context = edInvest;
            
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            var user = await _context.Users.OfType<TEntity>().FirstOrDefaultAsync(x=>x.Id == id);
            return user;

        }
        //i am not sure if this breaks the repository design, however for the time being I will use this, will get changed in the future
        public async Task<List<TEntity>> GetAll(TOptions options)
        {
            var users = await _context.Users
                .OfType<TEntity>() 
                .Where(u => u.Name.Contains(options.Name) || options.Name == null)
                .ToListAsync();
            return users;
            
        }
    }
}

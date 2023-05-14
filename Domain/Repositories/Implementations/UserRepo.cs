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
using Shared.Contracts.Responses.RankedInvestor;

namespace Domain.Repositories.Implementations
{
    public class UserRepo<TEntity, TGet, TOptions> 
        : IReadRepo<TEntity, TGet, TOptions>, IUserRepo<TEntity, TGet, TOptions> 
        where TEntity : User where TOptions : GetAllUsersBaseRequest
        where TGet : GetUserRequest
    {
        private readonly EdInvestContext _context;
        //private readonly _applicationMapper;

        public UserRepo(EdInvestContext edInvest
            )//, CourseMapper courseMapper) { 
        {
            _context = edInvest;
            
        }

        public async Task<TEntity?> GetById(TGet request)
        {
            var user = await _context.Users.OfType<TEntity>().FirstOrDefaultAsync(x=>x.Id == request.Id);
            return user;

        }
        //i am not sure if this breaks the repository design, however for the time being I will use this, will get changed in the future
        public async Task<List<TEntity>> GetAll(TOptions options)
        {
            var users = await _context.Users
                .OfType<TEntity>() 
                .Where(u => u.Name.Contains(options.Name) || options.Name == null)
                .Where(u=>u.CountryId == options.CountryId || options.CountryId == null)
                .ToListAsync();
            return users;
            
        }
        public async Task<TEntity?> GetUserByEmail(string email)
        {
           return await _context.Users
                .OfType<TEntity>().
                FirstOrDefaultAsync(x=>x.Email==email);
        }
        public async Task<List<RankedResponse>> GetInvestors(Guid itemId)
        {
            return await _context.Investments
                .Where(i=>i.ItemId == itemId)
                .Include(i=>i.Investor)
                .OrderByDescending(i=>i.Amount)
                .Select(i=> new RankedResponse
                {
                    Amount = i.Amount,
                    Email = i.Investor.Email,
                    Image = i.Investor.ProfilePicture,
                    InvestorId = i.InvestorId,
                    Name = i.Investor.Name                    
                })
                .ToListAsync();
        }
        public async Task<List<RankedResponse>> GetTopGlobalInvestors()
        {
            return await _context.Users
                .OfType<Investor>()
                .Include(u=>u.Investments)
                .OrderByDescending(u => u.Investments.Sum(i => i.Amount))
                .Take(10)
                .Select(i => new RankedResponse
                {
                    Amount = i.Investments.Sum(i => i.Amount),
                    Email = i.Email,
                    Image = i.ProfilePicture,
                    InvestorId = i.Id,
                    Name = i.Name
                })
                .ToListAsync();
        }

    }
}

using Data.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.RankedInvestor;
using Shared.Models.Users;

namespace Domain.Repositories.Implementations
{
    public class UserRepo<TEntity, TGet, TOptions>
        : IReadRepo<TEntity, TGet, TOptions>, IUserRepo<TEntity, TGet, TOptions>
        where TEntity : User where TOptions : GetAllUsersBaseRequest
        where TGet : GetUserRequest
    {
        private readonly EdInvestContext _context;

        public UserRepo(EdInvestContext edInvest
            )
        {
            _context = edInvest;

        }

        public async Task<TEntity?> GetById(TGet request)
        {
            var user = await _context.Users.OfType<TEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);
            return user;

        }
        public async Task<List<TEntity>> GetAll(TOptions options)
        {
            var users = await _context.Users
                .OfType<TEntity>()
                .Where(u => u.Name.Contains(options.Name) || options.Name == null)
                .Where(u => u.CountryId == options.CountryId || options.CountryId == null)
                .ToListAsync();
            return users;

        }
        public async Task<TEntity?> GetUserByEmail(string email)
        {
            return await _context.Users
                 .OfType<TEntity>().
                 FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<List<RankedResponse>> GetInvestors(Guid itemId)
        {
            return await _context.Investments
                .Where(i => i.ItemId == itemId)
                .Include(i => i.Investor)
                .OrderByDescending(i => i.Amount)
                .Select(i => new RankedResponse
                {
                    Amount = i.Amount,
                    Email = i.Investor.Email,
                    Image = i.Investor.ProfilePicture,
                    InvestorId = i.InvestorId,
                    Name = i.Investor.Name
                })
                .ToListAsync();
        }
       // public async GetInvestments(Guid Investment)
        public async Task<List<RankedResponse>> GetTopGlobalInvestors()
        {
            return await _context.Users
                .OfType<Investor>()
                .Include(u => u.Investments)
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

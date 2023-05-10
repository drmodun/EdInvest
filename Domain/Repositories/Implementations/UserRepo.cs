using Data.Entities;
using Data.Entities.Models.Items;
using Data.Entities.Models.Users;
using Data.Enums;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Requests.Users.User;
using Domain.Contracts.Responses.Items.Item;
using Domain.Contracts.Responses.Users.User;
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
    public class UserRepo : IReadRepo<User, Guid, GetAllUsersRequest, GetAllUsersResponse>, IUserRepo
    {
        private readonly EdInvestContext _context;
        //private readonly _applicationMapper;
        private readonly InvestorMapper _investorMapper;
        private readonly OrganisationMapper _organisationMapper;

        public UserRepo(EdInvestContext edInvest,
            InvestorMapper investorMapper, OrganisationMapper organisationMapper)//, CourseMapper courseMapper) { 
        {
            _context = edInvest;
            _investorMapper = investorMapper;
            _organisationMapper = organisationMapper;
        }

        public async Task<User?> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            switch (user.Type) {
                case UserType.Investor:
                    return user as Investor;
                case UserType.Organisation: return user as Organisation;
                case UserType.Student: return user as Student;
                default: return null;

            }
        }
        //i am not sure if this breaks the repository design, however for the time being I will use this, will get changed in the future
        public async Task<GetAllUsersResponse> GetAll(GetAllUsersRequest options)
        {
            var users = _context.Users
                .Where(u => u.Name.Contains(options.Name) || options.Name == null)
                .Where(u => u.Type == options.UserType || options.UserType == null);
            return new GetAllUsersResponse
            {
                Investors =  users.OfType<Investor>().Select(_investorMapper.ToDTO).ToList(),
                Organisations =  users.OfType<Organisation>().Select(_organisationMapper.ToDTO).ToList(),
                //Students =  users.OfType<Student>().Select(StudentMapper).ToList(),
            };
        }
    }
}

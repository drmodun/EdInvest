﻿using Data.Entities;
using Data.Entities.Models.Users;
using Data.Enums;
using Domain.Contracts.Requests.Users.User;
using Domain.Contracts.Responses.Users.User;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class UserRepo
    {
        private readonly EdInvestContext _context;
        public UserRepo(EdInvestContext edInvest) { 
            _context = edInvest;
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
        public async Task<GetAllUsersResponse> GetAll(GetAllUsersRequest options)
        {
            var users = _context.Users
                .Where(u => u.Name.Contains(options.Name) || options.Name == null)
                .Where(u => u.Type == options.UserType || options.UserType == null);
            return new GetAllUsersResponse
            {
                Investors = await users.OfType<Investor>().ToListAsync(),
                Organisations = await users.OfType<Organisation>().ToListAsync(),
                Students = await users.OfType<Student>().ToListAsync(),
            };
        }
    }
}

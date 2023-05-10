using Data.Entities.Models.Users;
using Domain.Contracts.Requests.Users.Investor;
using Domain.Contracts.Responses.Users.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public   class InvestorMapper
    {
        public   GetInvestorResponse ToGetInvestorResponse(Investor investor)
        {
            return new GetInvestorResponse
            {
                Id = investor.Id,
                Name = investor.Name,
                Email = investor.Email,
                Password = investor.Password,
                Balance = investor.Balance,
                NumberOfEmployees = investor.NumberOfEmployees,
                CreatedAt = investor.CreatedAt,
                UpdatedAt = investor.UpdatedAt,
                Description = investor.Description,
                ProfilePicture = investor.ProfilePicture,
                SocialLinks = investor.SocialLinks,
                IsAdmin = investor.IsAdmin,
                CountryId = investor.CountryId,
                LocationName = investor.LocationName,
                WalletAddress = investor.WalletAddress,
                Type = investor.Type
                

            };
        }
        public   Investor ToEntity (CreateInvestorRequest request)
        {
            return new Investor
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Balance = request.Balance,
                NumberOfEmployees = request.NumberOfEmployees,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = request.Description,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                IsAdmin = request.IsAdmin,
                CountryId = request.CountryId,
                LocationName = request.LocationName,
                WalletAddress = request.WalletAddress,
                Type = request.Type,
                

            };
        }
        public   Investor ToUpdatedEntity(UpdateInvestorRequest request)
        {
            return new Investor
            {
                Id =request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Balance = request.Balance,
                NumberOfEmployees = request.NumberOfEmployees,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = request.Description,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                IsAdmin = request.IsAdmin,
                CountryId = request.CountryId,
                LocationName = request.LocationName,
                WalletAddress = request.WalletAddress,
                Type = request.Type,


            };
        }

    }
}

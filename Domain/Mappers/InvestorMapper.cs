using Shared.Models.Users;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses.Users.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public   class InvestorMapper : IMapper<Investor, GetInvestorResponse, CreateInvestorRequest, UpdateInvestorRequest>
    {
        public   GetInvestorResponse ToDTO(Investor entity )
        {
            return new GetInvestorResponse
            {
                Id = entity .Id,
                Name = entity .Name,
                Email = entity .Email,
                Password = entity .Password,
                Balance = entity .Balance,
                NumberOfEmployees = entity .NumberOfEmployees,
                CreatedAt = entity .CreatedAt,
                UpdatedAt = entity .UpdatedAt,
                Description = entity .Description,
                ProfilePicture = entity .ProfilePicture,
                SocialLinks = entity .SocialLinks,
                IsAdmin = entity .IsAdmin,
                CountryId = entity .CountryId,
                LocationName = entity .LocationName,
                WalletAddress = entity .WalletAddress,
                Type = entity .Type
                

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
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
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
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
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

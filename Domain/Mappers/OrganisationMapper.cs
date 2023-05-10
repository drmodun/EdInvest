using Data.Entities.Models.Users;
using Domain.Contracts.Requests.Users.Investor;
using Domain.Contracts.Requests.Users.organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class OrganisationMapper
    {
        public static Organisation ToEntity(CreateOrganisationRequest request)
        {
            return new Organisation
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                NumberOfMembers = request.NumberOfMembers,
                Email = request.Email,
                Password = request.Password,
                Description = request.Description,
                LocationName = request.LocationName,
                Balance = request.Balance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                CountryId = request.CountryId,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                WalletAddress = request.WalletAddress,
                IsAdmin = request.IsAdmin
                


            };
        }
        public static Organisation ToUpdatedEntity (UpdateOrganisationRequest request)
        {
            return new Organisation
            {
                Id =request.Id,
                Name = request.Name,
                NumberOfMembers = request.NumberOfMembers,
                Email = request.Email,
                Password = request.Password,
                Description = request.Description,
                LocationName = request.LocationName,
                Balance = request.Balance,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                CountryId = request.CountryId,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                WalletAddress = request.WalletAddress,
                IsAdmin = request.IsAdmin



            };
        }
    }
}

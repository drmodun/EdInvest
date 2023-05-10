using Data.Entities.Models.Users;
using Domain.Contracts.Requests.Users.Investor;
using Domain.Contracts.Requests.Users.organisation;
using Domain.Contracts.Requests.Users.Student;
using Domain.Contracts.Responses.Users.Organisation;
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
        public static Organisation ToUpdatedEntity(UpdateOrganisationRequest request)
        {
            return new Organisation
            {
                Id = request.Id,
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
        public static GetOrganisationResponse ToDTO(Organisation organisation)
        {
            return new GetOrganisationResponse
            {
                Id = organisation.Id,
                Name = organisation.Name,
                Description = organisation.Description,
                LocationName = organisation.LocationName,
                Balance = organisation.Balance,
                UpdatedAt = DateTime.UtcNow,
                Type = organisation.Type,
                CountryId = organisation.CountryId,
                ProfilePicture = organisation.ProfilePicture,
                Email = organisation.Email,
                Password = organisation.Password,
                IsAdmin = organisation.IsAdmin,
                SocialLinks = organisation.SocialLinks,
                WalletAddress = organisation.WalletAddress,
                NumberOfMembers = organisation.NumberOfMembers,



            };

        }
    }
}

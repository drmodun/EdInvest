using Shared.Models.Users;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Requests.Users.organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Contracts.Responses.Users.Organisation;
using System;
using Shared.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public   class OrganisationMapper : IMapper<Organisation, GetOrganisationResponse, CreateOrganisationRequest, UpdateOrganisationRequest>
    {
        public   Organisation ToEntity(CreateOrganisationRequest request)
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
        public   Organisation ToUpdatedEntity(UpdateOrganisationRequest request)
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
        public   GetOrganisationResponse ToDTO(Organisation entity)
        {
            return new GetOrganisationResponse
            {
                Id = entity .Id,
                Name = entity .Name,
                Description = entity .Description,
                LocationName = entity .LocationName,
                Balance = entity .Balance,
                UpdatedAt = DateTime.UtcNow,
                Type = entity .Type,
                CountryId = entity .CountryId,
                ProfilePicture = entity .ProfilePicture,
                Email = entity .Email,
                Password = entity .Password,
                IsAdmin = entity .IsAdmin,
                SocialLinks = entity .SocialLinks,
                WalletAddress = entity .WalletAddress,
                NumberOfMembers = entity .NumberOfMembers,



            };

        }
    }
}

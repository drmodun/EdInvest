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
using Shared.Hash;
using Microsoft.AspNetCore.Identity;

namespace Domain.Mappers
{
    public   class OrganisationMapper : IMapper<Organisation, GetOrganisationResponse, CreateOrganisationRequest, UpdateOrganisationRequest>
    {
        public   Organisation ToEntity(CreateOrganisationRequest request)
        {
            if (request.Password.Length < 8)
                return null;
            if (request.Password == request.Password.ToLower())
                return null;
            //a robust password check beacause we are hashing stuff in the mapper already so it will never validate the password with validation
            return new Organisation
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                NumberOfMembers = request.NumberOfMembers,
                Email = request.Email,
                Password = HashHelper.Hash(request.Password),
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
                Claims = new Dictionary<string, string>()
                {
                    { "trusted_member", "true" }
                }



            };
        }
        public   Organisation? ToUpdatedEntity(UpdateOrganisationRequest request)
        {
            if (request.Password.Length < 8)
                return null;
            if (request.Password == request.Password.ToLower())
                return null;


            return new Organisation
            {
                Id = request.Id,
                Name = request.Name,
                NumberOfMembers = request.NumberOfMembers,
                Email = request.Email,
                Password = HashHelper.Hash(request.Password),
                Description = request.Description,
                LocationName = request.LocationName,
                Balance = request.Balance,
                UpdatedAt = DateTime.UtcNow,
                Type = request.Type,
                CountryId = request.CountryId,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                WalletAddress = request.WalletAddress,



            };
        }
        public   GetOrganisationResponse? ToDTO(Organisation entity)
        {
            if (entity.Password.Length<8)
                return null;
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
                SocialLinks = entity .SocialLinks,
                WalletAddress = entity .WalletAddress,
                NumberOfMembers = entity .NumberOfMembers,



            };

        }
    }
}

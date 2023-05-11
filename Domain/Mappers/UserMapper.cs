using Shared.Models.Users;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class UserMapper : IMapper<User, GetUserResponse, CreateUserRequest, UpdateUserRequest>
    {
        public GetUserResponse ToDTO(User entity)
        {
            return new GetUserResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                Balance = entity.Balance,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Description = entity.Description,
                ProfilePicture = entity.ProfilePicture,
                SocialLinks = entity.SocialLinks,
                IsAdmin = entity.IsAdmin,
                CountryId = entity.CountryId,
                LocationName = entity.LocationName,
                WalletAddress = entity.WalletAddress,
                Type = entity.Type
            };
        }
        public User ToEntity(CreateUserRequest entity) { 
            throw new NotImplementedException();
        }
        public User ToUpdatedEntity(UpdateUserRequest entity) { 
            throw new NotImplementedException();
        }

    }
}

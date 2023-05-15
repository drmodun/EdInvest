using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Users.User;
using Shared.Models.Users;

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
                Balance = entity.Balance,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Description = entity.Description,
                ProfilePicture = entity.ProfilePicture,
                SocialLinks = entity.SocialLinks,

                CountryId = entity.CountryId,
                LocationName = entity.LocationName,
                WalletAddress = entity.WalletAddress,
                Type = entity.Type
            };
        }
        public User ToEntity(CreateUserRequest entity)
        {
            throw new NotImplementedException();
        }
        public User ToUpdatedEntity(UpdateUserRequest entity)
        {
            throw new NotImplementedException();
        }

    }
}

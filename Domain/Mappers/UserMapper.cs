using Domain.Repositories.Implementations;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Users.User;
using Shared.Enums;
using Shared.Models.Users;

namespace Domain.Mappers
{
    public class UserMapper : IMapper<User, GetUserResponse, CreateUserRequest, UpdateUserRequest>
    {
        private readonly InvestmentRepo _investmentRepo;

        public UserMapper(InvestmentRepo investmentRepo)
        {
            _investmentRepo = investmentRepo;
        }

        public GetUserResponse ToDTO(User entity)
        {
            return new GetUserResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Balance = entity.Type == UserType.Investor ?
                _investmentRepo.GetSpent(entity.Id).Result :
                _investmentRepo.GetEarned(entity.Id).Result,
                UpdatedAt = entity.UpdatedAt,
                Description = entity.Description,
                ProfilePicture = entity.ProfilePicture,
                SocialLinks = entity.SocialLinks,


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

using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Hash;
using Shared.Models.Users;

namespace Domain.Mappers
{
    public class InvestorMapper : IMapper<Investor, GetInvestorResponse, CreateInvestorRequest, UpdateInvestorRequest>
    {
        public GetInvestorResponse ToDTO(Investor entity)
        {

            return new GetInvestorResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Balance = entity.Balance,
                NumberOfEmployees = entity.NumberOfEmployees,
                
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
        public Investor ToEntity(CreateInvestorRequest request)
        {
            if (request.Password.Length < 8)
                return null;
            if (request.Password == request.Password.ToLower())
                return null;
            return new Investor
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Password = HashHelper.Hash(request.Password),
                Balance = request.Balance,
                NumberOfEmployees = request.NumberOfEmployees,
                
                UpdatedAt = DateTime.UtcNow,
                Description = request.Description,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                Claims = new Dictionary<string, string>()
                {
                    { "trusted_member", "true" }
                },
                CountryId = request.CountryId,
                LocationName = request.LocationName,
                WalletAddress = request.WalletAddress,
                Type = request.Type,


            };
        }
        public Investor ToUpdatedEntity(UpdateInvestorRequest request)
        {
            if (request.Password.Length < 8)
                return null;
            if (request.Password == request.Password.ToLower())
                return null;
            return new Investor
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = HashHelper.Hash(request.Password),
                Balance = request.Balance,
                NumberOfEmployees = request.NumberOfEmployees,
                UpdatedAt = DateTime.UtcNow,
                Description = request.Description,
                ProfilePicture = request.ProfilePicture,
                SocialLinks = request.SocialLinks,
                CountryId = request.CountryId,
                LocationName = request.LocationName,
                WalletAddress = request.WalletAddress,
                Type = request.Type,


            };
        }

    }
}

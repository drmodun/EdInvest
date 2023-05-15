using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Investor
{
    public class CreateInvestorResponse : CreateUserResponse
    {
        public GetInvestorResponse Investor { get; set; }
    }
}

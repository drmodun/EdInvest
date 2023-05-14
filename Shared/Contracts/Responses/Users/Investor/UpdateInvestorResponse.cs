using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Investor
{
    public class UpdateInvestorResponse : UpdateUserResponse
    {
        public GetInvestorResponse Investor { get; set; }
    }
}

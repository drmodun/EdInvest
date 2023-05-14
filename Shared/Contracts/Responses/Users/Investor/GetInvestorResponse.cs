using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Investor
{
    public class GetInvestorResponse : GetUserResponse
    {
        public int NumberOfEmployees { get; set; }
        //public List<> Investments { get; set; }

    }
}

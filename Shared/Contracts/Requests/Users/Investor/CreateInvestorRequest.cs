using Shared.Contracts.Requests.Users.User;
using Shared.Enums;

namespace Shared.Contracts.Requests.Users.Investor
{
    public class CreateInvestorRequest : CreateUserRequest
    {
        public int NumberOfEmployees { get; set; }
        public UserType Type = UserType.Investor;
    }
}

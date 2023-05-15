using Shared.Contracts.Requests.Users.User;
using Shared.Enums;

namespace Shared.Contracts.Requests.Users.Investor
{
    public class UpdateOrganisationRequest : UpdateUserRequest
    {
        public int NumberOfMembers { get; set; }
        public UserType Type = UserType.Organisation;

    }
}

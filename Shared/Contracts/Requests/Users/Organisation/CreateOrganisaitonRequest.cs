using Shared.Contracts.Requests.Users.User;
using Shared.Enums;

namespace Shared.Contracts.Requests.Users.organisation

{
    public class CreateOrganisationRequest : CreateUserRequest
    {
        public int NumberOfMembers { get; set; }
        public UserType Type = UserType.Organisation;
    }
}

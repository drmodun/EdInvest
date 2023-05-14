using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Organisation
{
    public class GetOrganisationResponse : GetUserResponse
    {

        public int NumberOfMembers { get; set; }

    }
}

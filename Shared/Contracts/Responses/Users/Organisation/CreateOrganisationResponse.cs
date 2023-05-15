using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Organisation
{
    public class CreateOrganisationResponse : CreateUserResponse
    {
        public GetOrganisationResponse Organisation { get; set; }

    }
}

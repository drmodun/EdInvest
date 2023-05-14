using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Organisation
{
    public class UpdateOrganisationResponse : UpdateUserResponse
    {
        public GetOrganisationResponse Organisation { get; set; }
    }
}

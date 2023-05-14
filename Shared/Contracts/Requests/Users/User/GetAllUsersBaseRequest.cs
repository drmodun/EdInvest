namespace Shared.Contracts.Requests.Users.User
{
    public class GetAllUsersBaseRequest
    {
        public string? Name { get; set; }
        public Guid? CountryId { get; set; }
    }
}

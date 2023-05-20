namespace Shared.Contracts.Requests.Users.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }

        public string LocationName { get; set; }
        public string WalletAddress { get; set; }
    }
}

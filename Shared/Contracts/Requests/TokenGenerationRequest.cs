namespace Shared.Contracts.Requests
{
    public class TokenGenerationRequest
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public Dictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();
    }
}
using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Application
{
    public class GetaApplicationResponse : GetItemResponse
    {
        public DateTime EstimatedRelease { get; set; }
        public string AppPurpose { get; set; }

        public List<string> Markets { get; set; } = new List<string>();

        public List<string> Features { get; set; } = new List<string>();

        public int EstimatedNumberOfUsers { get; set; }
    }
}

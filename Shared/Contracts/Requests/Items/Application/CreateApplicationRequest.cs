using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Application
{
    public class CreateApplicationRequest : CreateItemRequest
    {
        public DateTime EstimatedRelease { get; set; }
        public string AppPurpose { get; set; }
        public ItemType Type = ItemType.Application;

        public List<string> Markets { get; set; } = new List<string>();
        public List<string> Features { get; set; } = new List<string>();
        public int EstimatedNumberOfUsers { get; set; }
    }
}

using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Event
{
    public class CreateEventRequest : CreateItemRequest
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Dictionary<string, string> Activities { get; set; }

        public decimal TicketPrice { get; set; }
        public List<string> NotableAttendees { get; set; }

        public List<string> NotableSpeakers { get; set; }

        public int Capacity { get; set; }

        public ItemType Type = ItemType.Event;

        public int ExpectedAttendance { get; set; }
    }
}

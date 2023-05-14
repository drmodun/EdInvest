using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Event
{
    public class UpdateEventRequest : UpdateItemRequest
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public decimal TicketPrice { get; set; }
        public Dictionary<string, string> Activities { get; set; }

        public ItemType Type = ItemType.Event;

        public List<string> NotableAttendees { get; set; }

        public List<string> NotableSpeakers { get; set; }

        public int Capacity { get; set; }

        public int ExpectedAttendance { get; set; }
    }
}
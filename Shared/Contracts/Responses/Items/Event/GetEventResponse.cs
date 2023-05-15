using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Event
{
    public class GetEventResponse : GetItemResponse
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Dictionary<string, string> Activities { get; set; }

        public List<string> NotableAttendees { get; set; }

        public List<string> NotableSpeakers { get; set; }

        public int Capacity { get; set; }
        public decimal TicketPrice { get; set; }

        public int ExpectedAttendance { get; set; }
    }
}

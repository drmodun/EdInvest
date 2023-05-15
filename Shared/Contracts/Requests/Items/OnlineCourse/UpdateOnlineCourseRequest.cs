using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.OnlineCourse
{
    public class UpdateOnlineCourseRequest : UpdateItemRequest
    {
        public Dictionary<string, string> LinksToChannels { get; set; }
        public Dictionary<string, string> Lessons { get; set; }
        public List<DateTime> LessonsDate { get; set; }
        public int AvarageDuration { get; set; }
        public ItemType Type = ItemType.OnlineCourse;

        public int ExpectedAudience { get; set; }

    }
}

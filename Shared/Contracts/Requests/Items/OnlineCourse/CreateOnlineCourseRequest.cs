using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.OnlineCourse
{
    public class CreateOnlineCourseRequest : CreateItemRequest
    {

        public Dictionary<string, string> LinksToChannels { get; set; }
        public Dictionary<string, string> Lessons { get; set; }

        public ItemType Type = ItemType.OnlineCourse;


        public List<DateTime> LessonsDate { get; set; }

        public int AvarageDuration { get; set; }

        public int ExpectedAudience { get; set; }
    }
}

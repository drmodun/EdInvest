using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.OnlineCourse
{
    public class GetOnlineCourseResponse : GetItemResponse
    {
        public Dictionary<string, string> LinksToChannels { get; set; }
        public Dictionary<string, string> Lessons { get; set; }

        public List<DateTime> LessonsDate { get; set; }

        public int AvarageDuration { get; set; }

        public int ExpectedAudience { get; set; }
    }
}

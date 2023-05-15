namespace Shared.Models.Items
{
    public class OnlineCourse : Item
    {
        public Dictionary<string, string> LinksToChannels { get; set; }
        public Dictionary<string, string> Lessons { get; set; }

        public List<DateTime> LessonsDate { get; set; }

        public int AvarageDuration { get; set; }

        public int ExpectedAudience { get; set; }




    }
}

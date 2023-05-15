using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Course
{
    public class CreateCourseRequest : CreateItemRequest
    {
        public int? ExpectedApplicants { get; set; }
        public int? ExpectedGraduates { get; set; }
        public ItemType Type = ItemType.Course;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Dictionary<string, string> Curriculum { get; set; } = new Dictionary<string, string>();
        public int? ActiveStudents { get; set; }



    }
}

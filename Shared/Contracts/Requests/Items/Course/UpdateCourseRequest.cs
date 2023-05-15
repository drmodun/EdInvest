using Shared.Contracts.Items.Item;
using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Course
{
    public class UpdateCourseRequest : UpdateItemRequest
    {
        public int? ExpectedApplicants { get; set; }
        public int? ExpectedGraduates { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Dictionary<string, string> Curriculum { get; set; } = new Dictionary<string, string>();
        public int? ActiveStudents { get; set; }
        public ItemType Type = ItemType.Course;

    }

}

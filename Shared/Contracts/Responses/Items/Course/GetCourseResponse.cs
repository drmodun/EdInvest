using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Course
{
    public class GetCourseResponse : GetItemResponse
    {

        public int? ExpectedApplicants { get; set; }
        public int? ExpectedGraduates { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Dictionary<string, string> Curriculum { get; set; } = new Dictionary<string, string>();
        public int? ActiveStudents { get; set; }
    }
}

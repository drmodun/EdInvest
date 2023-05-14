using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Course
{
    public class UpdateCourseResponse : UpdateItemResponse
    {
        public GetCourseResponse Course { get; set; }
    }
}

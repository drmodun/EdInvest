using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Course
{
    public class CreateCourseResponse : CreateItemResponse
    {

        public GetCourseResponse Course { get; set; }
    }
}

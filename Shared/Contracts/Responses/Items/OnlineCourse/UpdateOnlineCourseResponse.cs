using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.OnlineCourse
{
    public class UpdateOnlineCourseResponse : UpdateItemResponse
    {
        public GetOnlineCourseResponse OnlineCourse { get; set; }

    }
}

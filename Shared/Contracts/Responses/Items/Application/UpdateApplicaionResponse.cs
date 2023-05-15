using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Application
{
    public class UpdateApplicaionResponse : UpdateItemResponse
    {
        public GetaApplicationResponse Application { get; set; }
    }
}

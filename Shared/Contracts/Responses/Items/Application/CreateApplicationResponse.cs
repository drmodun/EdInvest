using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Application
{
    public class CreateApplicationResponse : CreateItemResponse
    {
        public GetaApplicationResponse Application { get; set; }



    }
}

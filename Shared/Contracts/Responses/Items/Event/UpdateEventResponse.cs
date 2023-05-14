using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Event
{
    public class UpdateEventResponse : UpdateItemResponse
    {
        public GetEventResponse Event { get; set; }

    }
}

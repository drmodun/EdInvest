using Shared.Contracts.Responses.Items.Item;

namespace Shared.Contracts.Responses.Items.Event
{
    public class CreateEventResponse : CreateItemResponse
    {
        public GetEventResponse Event { get; set; }

    }
}

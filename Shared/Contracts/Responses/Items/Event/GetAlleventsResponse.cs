using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Event
{
    public class GetAllEventsResponse
    {
        public List<GetEventResponse> Events { get; set; }
    }
}

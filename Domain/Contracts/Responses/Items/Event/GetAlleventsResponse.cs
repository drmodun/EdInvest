using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.Event
{
    public class GetAlleventsResponse
    {
        public List<GetEventResponse> Events { get; set; }
    }
}

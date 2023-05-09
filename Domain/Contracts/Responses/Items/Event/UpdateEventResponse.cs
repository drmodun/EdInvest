using Domain.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.Event
{
    public class UpdateEventresponse : UpdateItemResponse
    {
        public GetEventResponse Event { get; set; }

    }
}

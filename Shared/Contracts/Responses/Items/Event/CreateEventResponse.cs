﻿using Shared.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Event
{
    public class CreateEventResponse : CreateItemResponse
    {
        public GetEventResponse Event { get; set; }

    }
}
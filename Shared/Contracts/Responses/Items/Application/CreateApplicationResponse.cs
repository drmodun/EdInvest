using Shared.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Application
{
    public class CreateApplicationResponse : CreateItemResponse
    {
        public GetaApplicationResponse Application { get; set; }



    }
}

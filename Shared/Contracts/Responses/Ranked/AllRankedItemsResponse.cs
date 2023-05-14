using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Ranked
{
    public class AllRankedItemsResponse
    {
       
        public List<RankedItemResponse> Items { get; set; }
    }
}

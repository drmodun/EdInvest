using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.RankedInvestor
{
    public class AllRankedResponse
    {
        public List<RankedResponse> Investors { get; set; }
    }
}

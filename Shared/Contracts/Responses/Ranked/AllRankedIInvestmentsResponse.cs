using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Ranked
{
    public class AllRankedInvestmentsResponse
    {
        public List<RankedInvestmentResponse> Investments { get; set; }
    }
}

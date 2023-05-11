using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Investments
{
    public class GetAllInvestmentsResponse
    {
        public List<GetInvestmentResponse> Investments { get; set;}
    }
}

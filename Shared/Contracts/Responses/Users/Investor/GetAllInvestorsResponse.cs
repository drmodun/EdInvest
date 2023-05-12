using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Users.Investor
{
    public class GetAllInvestorsResponse
    {
        public List<GetInvestorResponse> Investors { get; set; }
    }
}

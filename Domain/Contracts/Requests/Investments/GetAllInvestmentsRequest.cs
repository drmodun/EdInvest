using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Investments
{
    public class GetAllInvestmentsRequest
    {
        public Guid? ItemId { get; set; }
        public Guid? InvestorId { get; set; }
        public int? Tier { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

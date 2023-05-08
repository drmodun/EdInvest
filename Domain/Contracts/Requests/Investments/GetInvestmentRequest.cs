using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Investments
{
    public class GetInvestmentRequest
    {
        public Guid InvestorId { get; set; }

        public Guid CourseId { get; set; }
    }
}

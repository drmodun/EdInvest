using Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Investments
{
    public class CreateInvestmentRequest
    {
        public Guid? InvestorId { get; set; }
        public Guid ItemId { get; set; }
        public int Tier
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
    }
}

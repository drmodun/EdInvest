using Domain.Contracts.Responses.Items.Item;
using Domain.Contracts.Responses.Users.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Investments
{
    public class GetInvestmentResponse
    {

        public Guid InvestorId { get; set; }
        public Guid ItemId { get; set; }

        public int Tier
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

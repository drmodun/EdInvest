using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Ranked
{
    public class RankedInvestmentResponse
    {
        public string InvestorName { get; set; }
        public string OrganisationName { get; set; }

        public int Tier { get; set; }

        public decimal Amount { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string ItemImage { get; set; }

        public string InvestorImage { get; set; }

        public string ItemName { get; set; }

        public Guid ItemId { get; set; }

        public Guid InvestorId { get; set; }
        public Guid OrganisationId { get; set; }
    }
}

﻿namespace Shared.Contracts.Requests.Investments
{
    public class GetAllInvestmentsRequest
    {
        public Guid? ItemId { get; set; }
        public Guid? InvestorId { get; set; }
        public int? Tier { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

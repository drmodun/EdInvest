namespace Shared.Contracts.Requests.Investments
{
    public class UpdateInvestmentRequest
    {
        public Guid? InvestorId;
        public Guid ItemId;
        public int Tier
        {
            get; set;
        }
        public DateTime UpdatedAt { get; set; }
    }
}

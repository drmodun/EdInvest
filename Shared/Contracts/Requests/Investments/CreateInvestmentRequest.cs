namespace Shared.Contracts.Requests.Investments
{
    public class CreateInvestmentRequest
    {
        public Guid? InvestorId { get; set; }
        public Guid ItemId { get; set; }
        public decimal Amount { get; set; }
        public int Tier
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
    }
}

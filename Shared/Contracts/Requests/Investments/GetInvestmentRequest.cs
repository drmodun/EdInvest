namespace Shared.Contracts.Requests.Investments
{
    public class GetInvestmentRequest
    {
        public Guid InvestorId { get; set; }

        public Guid itemId { get; set; }
    }
}

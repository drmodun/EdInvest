namespace Shared.Contracts.Responses.RankedInvestor
{
    public class RankedResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Image { get; set; }
        public decimal Amount { get; set; }

        public Guid InvestorId { get; set; }



    }
}

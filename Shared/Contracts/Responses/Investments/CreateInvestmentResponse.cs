namespace Shared.Contracts.Responses.Investments
{
    public class CreateInvestmentResponse
    {
        public bool Success { get; set; }

        public GetInvestmentResponse Investment { get; set; }
    }
}

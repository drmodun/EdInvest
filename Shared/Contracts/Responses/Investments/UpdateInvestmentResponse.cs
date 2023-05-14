namespace Shared.Contracts.Responses.Investments
{
    public class UpdateInvestmentResponse
    {
        public bool? Success { get; set; }
        public GetInvestmentResponse? Investment { get; set; }

    }
}

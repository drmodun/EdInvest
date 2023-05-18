using Shared.Contracts.Responses.Ranked;

namespace Shared.Contracts.Responses.Investments
{
    public class CreateInvestmentResponse
    {
        public bool Success { get; set; }

        public RankedInvestmentResponse Investment { get; set; }
    }
}

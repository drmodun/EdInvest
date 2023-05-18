using Shared.Contracts.Responses.Ranked;

namespace Shared.Contracts.Responses.Investments
{
    public class GetAllInvestmentsResponse
    {
        public List<RankedInvestmentResponse> Investments { get; set; }
    }
}

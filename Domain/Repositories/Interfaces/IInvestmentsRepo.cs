using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Responses.Ranked;
using Shared.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IInvestmentsRepo
    {
        public Task<Investments?> GetById(GetInvestmentRequest request);
        public Task<List<Investments>> GetAll(GetAllInvestmentsRequest options);
    }
}

using Shared.Models;
using Shared.Contracts.Requests.Investments;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IInvestmentsRepo
    {
        public Task<Investments?> GetById(N_NKey id);
        public Task<List<Investments>> GetAll(GetAllInvestmentsRequest options);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Investments
{
    public class DeleteInvestmentRequest
    {
        public Guid InvaestorId { get; set; }
        public Guid ItemId { get; set; }
    }
}

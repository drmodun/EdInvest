using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Investments
{
    public class DeleteInvestmentRRequest
    {
        public Guid InvaestorId { get; set; }
        public Guid CourseId { get; set; }
    }
}

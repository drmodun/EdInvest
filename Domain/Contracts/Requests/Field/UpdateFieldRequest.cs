using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Field
{
    public class UpdateFieldRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}

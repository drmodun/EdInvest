using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Field
{
    public class UpdateFieldResponse
    {
        public GetFieldResponse Field { get; set; }

        public bool Success { get; set; }
    }
}

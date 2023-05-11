using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Field
{
    public class CreateFieldResponse
    {
        public bool ? Success { get; set; }

        public GetFieldResponse Field { get; set; }

    }
}

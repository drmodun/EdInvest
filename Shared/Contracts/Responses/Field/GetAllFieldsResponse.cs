using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Field
{
    public class GetAllFieldsResponse
    {
        public List<GetFieldResponse> Fields { get; set; }
    }
}

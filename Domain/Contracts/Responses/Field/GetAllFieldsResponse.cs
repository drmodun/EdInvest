using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Field
{
    public class GetAllFieldsResponse
    {
        public List<GetFieldResponse> Fields { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Application
{
    public class GetAllApplicationsResponse
    {

        public List<GetaApplicationResponse> Applications { get; set; }
    }
}

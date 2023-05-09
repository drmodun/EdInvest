using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.Organisation
{
    public class GetAllOrganisationsResponse
    {
        public List<GetOrganisationResponse> Organisations { get; set; }

    }
}

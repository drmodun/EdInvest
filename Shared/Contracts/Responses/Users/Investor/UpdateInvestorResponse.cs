using Shared.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Users.Investor
{
    public class UpdateInvestorResponse : UpdateUserResponse
    {
        public GetInvestorResponse Investor { get; set; }
    }
}

using Shared.Contracts.Requests.Users.User;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Users.Investor
{
    public class UpdateInvestorRequest : UpdateUserRequest
    {
        public int NumberOfEmployees { get; set; }
        public UserType Type = UserType.Investor;


    }
}

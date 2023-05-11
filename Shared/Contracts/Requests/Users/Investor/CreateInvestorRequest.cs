using Domain.Contracts.Requests.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Users.Investor
{
    public class CreateInvestorRequest : CreateUserRequest
    {
        public int NumberOfEmployees { get; set; }
    }
}

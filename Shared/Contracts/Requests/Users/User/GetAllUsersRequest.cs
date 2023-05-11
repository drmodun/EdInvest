using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Users.User
{
    public class GetAllUsersRequest
    {
        public string? Name { get; set; }
        public UserType? UserType { get; set; }
    }
}

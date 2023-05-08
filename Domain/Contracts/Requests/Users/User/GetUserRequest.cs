using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Users.User
{
    public class GetUserRequest
    {
        public Guid Id { get; set; }
    }
}

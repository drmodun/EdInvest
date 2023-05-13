using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Users.User
{
    public class GetAllUsersBaseRequest
    {
        public string? Name { get; set; }
        public Guid? CountryId { get; set; }
    }
}

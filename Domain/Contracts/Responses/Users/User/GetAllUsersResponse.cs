using Data.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.User
{
    public class GetAllUsersResponse
    {
        public List<Data.Entities.Models.Users.Investor> Investors { get; set; } = new();
        public List<Data.Entities.Models.Users.Organisation> Organisations { get; set; } = new();
        public List<Data.Entities.Models.Users.Student> Students { get; set; } = new();

    }
}

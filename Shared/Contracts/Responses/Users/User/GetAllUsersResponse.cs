using Shared.Models.Users;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Contracts.Responses.Users.Organisation;
using Shared.Contracts.Responses.Users.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Users.User
{
    public class GetAllUsersResponse
    {
        public List<GetUserResponse> Users { get; set; }
        //Add students in the future
        //public List<GetStudentResponse> Students { get; set; } = new();

    }
}

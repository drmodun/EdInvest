using Data.Entities.Models.Users;
using Domain.Contracts.Responses.Users.Investor;
using Domain.Contracts.Responses.Users.Organisation;
using Domain.Contracts.Responses.Users.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.User
{
    public class GetAllUsersResponse
    {
        public List<GetUserResponse> Users { get; set; }
        //Add students in the future
        //public List<GetStudentResponse> Students { get; set; } = new();

    }
}

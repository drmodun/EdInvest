using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.Student
{
    public class GetAllStudentsResponse
    {
        public List<GetStudentResponse> Students { get; set; }
    }
}

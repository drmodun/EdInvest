using Data.Entities.Models.Users;
using Domain.Contracts.Requests.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Users.Student
{
    public class CreateStudentRequest : CreateUserRequest
    {
        public Guid? FunderId { get; set; }

        public Guid FieldId { get; set; }

        public decimal SchoolarshipPrice { get; set; }

        public string CV { get; set; }

        public string CollegeName { get; set; }

        public string CollegeWebsite { get; set; }


        public string Course { get; set; }

        public DateTime BegginingOfEducation { get; set; }

        public DateTime EndOfEducation { get; set; }
    }
}

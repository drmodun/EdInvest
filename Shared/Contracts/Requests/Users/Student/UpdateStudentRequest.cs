﻿using Shared.Contracts.Requests.Users.User;
using Shared.Enums;

namespace Shared.Contracts.Requests.Users.Student
{
    public class UpdateStudentRequest : UpdateUserRequest
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
        public UserType Type = UserType.Student;
    }
}

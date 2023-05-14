using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Student
{
    public class GetStudentResponse : GetUserResponse
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

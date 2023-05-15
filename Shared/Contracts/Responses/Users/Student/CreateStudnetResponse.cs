using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Student
{
    public class CreateStudnetResponse : GetUserResponse
    {
        public GetStudentResponse Student { get; set; }

    }
}

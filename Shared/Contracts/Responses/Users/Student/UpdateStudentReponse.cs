using Shared.Contracts.Responses.Users.User;

namespace Shared.Contracts.Responses.Users.Student
{
    public class UpdateStudentReponse : UpdateUserResponse
    {
        public GetStudentResponse Student { get; set; }


    }
}

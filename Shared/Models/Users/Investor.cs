namespace Shared.Models.Users
{
    public class Investor : User
    {
        public int NumberOfEmployees { get; set; }
        public ICollection<Investments> Investments { get; set; } = new List<Investments>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

using Shared.Models.Users;

namespace Shared.Models
{
    public class Field
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

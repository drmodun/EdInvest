using Shared.Models.Items;

namespace Shared.Models.Users
{
    public class Organisation : User
    {
        public int NumberOfMembers { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

    }
}

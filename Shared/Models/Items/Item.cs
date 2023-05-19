using Shared.Enums;
using Shared.Models.Users;

namespace Shared.Models.Items
{
    public abstract class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();


        public ItemType Type { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public Guid OrganisationId { get; set; }
        public Organisation? Organisation { get; set; }


        public string MainWebsite { get; set; }
        public decimal Goal { get; set; }
        public List<decimal> Prices { get; set; }
        public Dictionary<string, string> Tiers { get; set; } = new Dictionary<string, string>();
        public ICollection<Investments> Investments = new List<Investments>();
    }
}

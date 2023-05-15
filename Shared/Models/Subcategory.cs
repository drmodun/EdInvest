using Shared.Models.Items;

namespace Shared.Models
{
    public class Subcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get; set;
        }
        public Guid CategoryId 
        {
            get; set;
        }
        public Category? Category { get; set; }
        public ICollection<Item> Items = new List<Item>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Items;

namespace Shared.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public ICollection<Subcategory> Subcategories = new List<Subcategory>();
        public ICollection<Item> Items = new List<Item>();
    }
}

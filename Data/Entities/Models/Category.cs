using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Category
    {
        public Guid Id;
        public string Name;
        public string Description;
        public ICollection<Subcategory> Subcategories = new List<Subcategory>();
    }
}

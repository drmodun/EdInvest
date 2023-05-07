using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Subcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get; set;
        }
        public Guid CatgoryId 
        {
            get; set;
        }
        public Category? Category { get; set; }
        public ICollection<Item> Courses = new List<Item>();
    }
}

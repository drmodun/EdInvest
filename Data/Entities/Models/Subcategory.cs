using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Subcategory
    {
        public Guid Id;
        public string Name;
        public string Description;
        public Guid CatgoryId;
        public Category? Category;
    }
}

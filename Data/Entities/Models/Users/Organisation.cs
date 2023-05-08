using Data.Entities.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models.Users
{
    public class Organisation : User
    {
        public int NumberOfMembers { get; set; }

        public string Location { get; set; }
        public ICollection<Item> Courses { get; set; } = new List<Item>();

    }
}

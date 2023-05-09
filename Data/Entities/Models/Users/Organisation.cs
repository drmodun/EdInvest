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

        public ICollection<Item> Items { get; set; } = new List<Item>();

    }
}

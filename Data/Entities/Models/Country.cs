using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public ICollection<User> Users = new List<User>();  
    }
}

using Data.Entities.Models.Items;
using Data.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Investments
    {
        public Guid InvestorId { get; set; }
        public Investor? Investor { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public int Tier
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

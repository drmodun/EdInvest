using Data.Entities.Models.Items;
using Data.Entities.Models.Users;
using Data.Migrations;
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
        public Guid CourseId { get; set; }
        public Item? Course { get; set; }
        public int Tier
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

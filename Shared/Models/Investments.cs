using Shared.Models.Items;
using Shared.Models.Users;

namespace Shared.Models
{
    public class Investments
    {
        public Guid InvestorId { get; set; }
        public Investor? Investor { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }

        public decimal Amount { get; set; }
        public int Tier
        {
            get; set;
        }
        
        public DateTime UpdatedAt { get; set; }
    }

}

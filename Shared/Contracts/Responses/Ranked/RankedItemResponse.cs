using Shared.Enums;
using System.Globalization;

namespace Shared.Contracts.Responses.Ranked
{
    public class RankedItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public Guid OrganisationId { get; set; }

        public string OrganisationName { get; set; }

        public string ItemDescription { get; set; }

        public decimal Goal { get; set; }

        public decimal CurrentAmount { get; set; }

        public string Image { get; set; }

        public int Tier { get; set; }

        public DateTime? Updated { get; set; }

        public ItemType Type { get; set; }
    }
}

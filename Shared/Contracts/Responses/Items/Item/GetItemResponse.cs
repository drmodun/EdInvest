﻿using Shared.Enums;

namespace Shared.Contracts.Responses.Items.Item
{
    public class GetItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string OrganisationName { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();

        public int NumberOfDonations { get; set; }

        public ItemType Type { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubcategoryId { get; set; }
        public Guid OrganisationId { get; set; }

        public decimal Goal { get; set; }


        public decimal CurrentAmount { get; set; }

        public List<decimal> Prices { get; set; }

        public string MainWebsite { get; set; }

        public Dictionary<string, string> Tiers { get; set; } = new Dictionary<string, string>();

    }
}

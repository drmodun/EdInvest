﻿namespace Shared.Contracts.Items.Item
{
    public abstract class CreateItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public Guid CategoryId { get; set; }
        public Guid SubcategoryId { get; set; }
        public Guid OrganisationId;

        public decimal Goal { get; set; }

        public string MainWebsite { get; set; }
        public List<decimal> Prices { get; set; }
        public Dictionary<string, string> Tiers { get; set; } = new Dictionary<string, string>();
    }
}

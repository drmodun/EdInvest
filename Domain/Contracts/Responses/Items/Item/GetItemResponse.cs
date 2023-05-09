﻿using Data.Entities.Models.Users;
using Data.Entities.Models;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Responses.Investments;
using Domain.Contracts.Responses.Users.Investor;

namespace Domain.Contracts.Responses.Items.Item
{
    public abstract  class GetItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }

        public ItemType Type { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubcategoryId { get; set; }
        public Guid OrganisationId { get; set; }

        public decimal Goal { get; set; }

        public Guid CountryId { get; set; }

        public decimal CurrentAmount { get; set; }

        public List<decimal> Prices { get; set; }
        public Dictionary<string, string> Tiers { get; set; } = new Dictionary<string, string>();
        public List<GetInvestmentResponse> Investments { get; set; }

        public List<GetInvestorResponse> Investors { get; set; }
    }
}

using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Ranked
{
    public class RankedItemResponse
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public Guid OrganisationId { get; set; }

        public string Image { get; set; }

        public DateTime? Updated { get; set; }

        public ItemType Type { get; set; }
    }
}

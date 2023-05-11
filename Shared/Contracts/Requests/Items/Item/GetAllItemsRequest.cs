using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Items.Item
{
    public class GetAllItemsRequest
    {
        public string? Name { get; set; }  

        public Guid? SubcategoryId { get; set; }

        public Guid? CategoryId { get; set; }

        public ItemType? ItemType { get; set; }

        public Guid? OrganisationId { get; set; }
    }
}

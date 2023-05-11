using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Items.Item
{
    public abstract class GetItemRequest
    {
        public Guid Id { get; set; }
    }
}

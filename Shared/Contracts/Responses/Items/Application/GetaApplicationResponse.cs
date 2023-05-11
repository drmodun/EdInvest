using Shared.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Application
{
    public class GetaApplicationResponse : GetItemResponse
    {
        public DateTime EstimatedRelease { get; set; }
        public string AppPurpose { get; set; }

        public List<string> Markets { get; set; } = new List<string>();

        public List<string> Features { get; set; } = new List<string>();

        public int EstimatedNumberOfUsers { get; set; }
    }
}

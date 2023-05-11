using Shared.Models.Items;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Event;
using Shared.Contracts.Responses.Items.OnlineCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Item
{
    public class GetAllItemsResponse
    {
        public List<GetItemResponse> Items { get; set; }
    }
}

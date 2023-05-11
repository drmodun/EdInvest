using Data.Entities.Models.Items;
using Domain.Contracts.Responses.Items.Application;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Event;
using Domain.Contracts.Responses.Items.OnlineCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.Item
{
    public class GetAllItemsResponse
    {
        public List<GetItemResponse> Items { get; set; }
    }
}

using Data.Entities.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.Item
{
    public class GetAllItemsResponse
    {
        public List<Data.Entities.Models.Items.Application> Applications = new List<Data.Entities.Models.Items.Application>();
        public List<Data.Entities.Models.Items.Course> Courses = new List<Data.Entities.Models.Items.Course>();
        public List<Data.Entities.Models.Items.Event> Events = new List<Data.Entities.Models.Items.Event>();
        public List<Data.Entities.Models.Items.OnlineCourse> OnlineCourses = new List<Data.Entities.Models.Items.OnlineCourse>();
    }
}

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
        public List<GetaApplicationResponse> Applications = new ();
        public List<GetCourseResponse> Courses = new();
        public List<GetEventResponse> Events = new();
        public List<GetOnlineCourseResponse> OnlineCourses = new();
    }
}

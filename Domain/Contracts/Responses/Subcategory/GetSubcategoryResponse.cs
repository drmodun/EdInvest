using Domain.Contracts.Requests.Items.OnlineCourse;
using Domain.Contracts.Responses.Items.Application;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Subcategory
{
    public class GetSubcategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        public List<GetaApplicationResponse> Applications { get; set; }
        public List<GetEventResponse> Evnets { get; set; }
        public List<GetCourseResponse> Courses { get; set; }
        public List<GetOnlineCourseRequest> OnlineCourses { get; set; }

    }
}

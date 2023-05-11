using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Items.Course
{
    public class GetAllCoursesResponse
    {
        public List<GetCourseResponse>  Courses { get; set; }
    }
}

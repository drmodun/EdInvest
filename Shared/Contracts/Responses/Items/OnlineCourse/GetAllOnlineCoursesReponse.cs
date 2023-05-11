using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.OnlineCourse
{
    public class GetAllOnlineCoursesReponse 
    {
        public List<GetOnlineCourseResponse> OnlineCourses { get; set; }
    }
}

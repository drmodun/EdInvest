using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Subcategory
{
    public class GetSubcategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        public string Description { get; set; }


    }
}

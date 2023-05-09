using Domain.Contracts.Requests.Items.OnlineCourse;
using Domain.Contracts.Responses.Items.Application;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Event;
using Domain.Contracts.Responses.Subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Category
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<GetSubcategoryResponse> Subcategories { get; set; }
    }
}

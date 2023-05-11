using Domain.Contracts.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Category
{
    public class UpdateCategoryResponse
    {
        public bool Success { get; set; }
        public GetCategoryRequest? Category { get; set; }
    }
}

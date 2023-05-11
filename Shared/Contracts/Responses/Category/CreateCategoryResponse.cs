using Shared.Contracts.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Category
{
    public class CreateCategoryResponse
    {
        public bool Success { get; set; }
        public GetCategoryRequest? Category { get; set; }
    }
}

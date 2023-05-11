using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Subcategory
{
    public class CreateSubcategoryResponse
    {
        public GetSubcategoryResponse Subcategory { get; set; }
        public bool Success { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Subcategory
{
    public class GetAllSubcategoriesRequest 
    {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
    }
}

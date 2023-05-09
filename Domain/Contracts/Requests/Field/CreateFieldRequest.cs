using Data.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Field
{
    public class CreateFieldRequest
    {
        public string Name { get; set; }
    }
}

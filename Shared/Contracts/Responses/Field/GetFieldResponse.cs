using Shared.Contracts.Responses.Users.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Field
{
    public class GetFieldResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}

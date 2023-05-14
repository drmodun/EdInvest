using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests
{
    public class LoginUserRequset
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

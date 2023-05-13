using Shared.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Users.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }

        public bool? IsAdmin { get; set; }

        public Guid CountryId { get; set; }
        public string LocationName { get; set; }
        public string WalletAddress { get; set; }
        public decimal? Balance { get; set; }
    }
}

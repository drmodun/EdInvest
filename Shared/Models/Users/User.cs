using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Users
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }

        public Dictionary<string, string> Claims { get; set; }
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
        public string LocationName { get; set; }
        public string WalletAddress { get; set; }
        public decimal? Balance { get; set; }

        public UserType Type { get; set; }


    }
}

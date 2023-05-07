using Data.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models.Users
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
        public string PhoneNumber { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }

        public bool? IsAdmin { get; set; }

        public Guid CountryId;
        public Country? Country { get; set; }
        public string LocationName { get; set; }
        public string WalletAddress { get; set; }
        public decimal? Balance { get; set; }

        public UserType Type { get; set; }


    }
}

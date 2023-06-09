﻿using Shared.Enums;

namespace Shared.Models.Users
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }

        public Dictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();
        public string LocationName { get; set; }
        public string WalletAddress { get; set; }

        public UserType Type { get; set; }


    }
}

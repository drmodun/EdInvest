﻿
using Shared.Enums;

namespace Shared.Contracts.Responses.Users.User
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public Dictionary<string, string> SocialLinks { get; set; }



        public string LocationName { get; set; }
        public string WalletAddress { get; set; }
        public decimal? Balance { get; set; }

        public UserType Type { get; set; }

    }
}

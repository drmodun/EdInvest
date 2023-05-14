﻿namespace API.Auth
{
    public static class UserExtension
    {
        public static Guid? GetUserId(this HttpContext context)
        {
            var userId = context.User.Claims.SingleOrDefault(x => x.Type == "userid");

            if (Guid.TryParse(userId?.Value, out var parsedId))
            {
                return parsedId;
            }

            return null;
        }
    }
}

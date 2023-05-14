using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Constants
{
    public static class AuthConstants
    {
        public const string AdminUserPolicyName = "Admin";
        public const string AdminUserClaimName = "admin";
        public const string TrustMemberPolicyName = "Trusted";
        public const string TrustedMemberClaimName = "trusted_member";
    }
}
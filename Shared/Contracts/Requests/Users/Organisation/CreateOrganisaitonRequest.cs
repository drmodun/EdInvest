﻿using Shared.Contracts.Requests.Users.User;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Users.organisation

{
    public class CreateOrganisationRequest : CreateUserRequest
    {
        public int NumberOfMembers { get; set; }
        public UserType Type = UserType.Organisation;
    }
}

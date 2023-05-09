﻿using Domain.Contracts.Requests.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests.Users.organisation

{
    public class CreateOrganisationRequest : CreateUserRequest
    {
        public int NumberOfMembers { get; set; }
    }
}
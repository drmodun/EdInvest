﻿using Domain.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.Organisation
{
    public class UpdateOrganisationResponse : UpdateUserResponse
    {
        public GetOrganisationResponse Organisation { get; set; }
    }
}

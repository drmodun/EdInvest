﻿using Domain.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.Student
{
    public class UpdateStudentReponse : UpdateUserResponse
    {
        public GetStudentResponse Student { get; set; }

     
    }
}

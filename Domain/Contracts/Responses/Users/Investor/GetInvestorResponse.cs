using Data.Entities.Models;
using Domain.Contracts.Requests.Items.OnlineCourse;
using Domain.Contracts.Responses.Items.Application;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Event;
using Domain.Contracts.Responses.Users.Student;
using Domain.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Users.Investor
{
    public class GetInvestorResponse : GetUserResponse
    {
        public int NumberOfEmployees { get; set; }
        //public List<> Investments { get; set; }
       
    }
}

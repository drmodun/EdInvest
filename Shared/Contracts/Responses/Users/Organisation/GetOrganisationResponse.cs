using Shared.Models.Items;
using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Event;
using Shared.Contracts.Responses.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Responses.Users.Organisation
{
    public class GetOrganisationResponse : GetUserResponse
    {

        public int NumberOfMembers { get; set; }

    }
}

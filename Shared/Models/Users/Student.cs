using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models.Users
{
    public class Student : User
    {
        public Guid? FunderId { get; set; }
        public Investor? Funder { get; set; }

        public Guid FieldId { get; set; }

        public decimal SchoolarshipPrice { get; set; }

        public string CV { get; set; }

        public string CollegeName { get; set; }

        public string CollegeWebsite { get; set; }


        public string Course { get; set; }

        public DateTime BegginingOfEducation { get; set; }

        public DateTime EndOfEducation { get; set; }
        public Field? Field { get; set; }
    }
}

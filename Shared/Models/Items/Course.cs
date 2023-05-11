using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models.Items
{
    public class Course : Item
    {
        public int? ExpectedApplicants { get; set; }
        public int? ExpectedGraduates { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Dictionary<string, string> Curriculum { get; set; } = new Dictionary<string, string>();
        public int? ActiveStudents { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Investments
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public decimal Amount 
        {
            get; set;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

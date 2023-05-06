using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Investments
    {
        public Guid Id;
        public Guid UserId;
        public User? User;
        public Guid CourseId;
        public Course? Course;
        public decimal Amount;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Course
    {
        public Guid Id;
        public string Name;
        public string Description;
        public List<string> Images;
        public List<string> Tags;
        public DateTime CreatedAt;
        
        public DateTime UpdatedAt;
        public Guid CategorId;
        public Category? Category;
        public Guid SubcategoryId;
        public Subcategory? Subcategory;
        public decimal Goal;
        public decimal CurrentAmount;
        public int? ExpectedApplicants;
        public int? ExpectedGraduates;
        public decimal? Passrate;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public Guid DoneeId;
        public User? Donee;
        public int? ActiveStudents;
        public ICollection<Investments> Investments = new List<Investments>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public decimal Goal { get; set; }
        public decimal CurrentAmount { get; set; }
        public int? ExpectedApplicants { get; set; }
        public int? ExpectedGraduates { get; set; }
        public decimal? Passrate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid DoneeId { get; set; }
        public User? Donee { get; set; }
        public int? ActiveStudents { get; set; }
        public ICollection<Investments> Investments = new List<Investments>();
    }
}

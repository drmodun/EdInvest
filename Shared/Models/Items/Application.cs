using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models.Items
{
    public class Application : Item
    {
        public DateTime EstimatedRelease { get; set; }
        public string AppPurpose { get; set; }

        public List<string> Markets { get; set; } = new List<string>();

        public List<string> Features { get; set; } = new List<string>();

        public int EstimatedNumberOfUsers { get; set; }
    }
}

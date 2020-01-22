using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicatin.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Skill { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}

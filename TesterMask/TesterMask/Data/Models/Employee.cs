using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeTasks = new HashSet<EmployeeTask>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        public string Phone { get; set; }
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }

    }
}

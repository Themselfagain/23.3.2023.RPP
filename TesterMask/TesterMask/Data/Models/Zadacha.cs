using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesterMask.Data.Models.Enum;

namespace TesterMask.Data.Models
{
    public class Zadacha
    {
        public Zadacha()
        {
            this.employeeTasks = new HashSet<EmployeeTask>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public ExecutionType executionType { get; set; }
        [Required]
        public LabelType labelType { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public IEnumerable<EmployeeTask> employeeTasks { get; set; }
    }
}

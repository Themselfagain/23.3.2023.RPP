using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Zadachi = new HashSet<Zadacha>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<Zadacha> Zadachi { get; set; }
    }
}

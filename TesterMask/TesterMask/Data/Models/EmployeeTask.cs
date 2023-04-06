using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterMask.Data.Models
{
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ZadachaId { get; set; }
        public Zadacha Zadacha { get; set; }

    }
}

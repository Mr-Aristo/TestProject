using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string? EmployeeName { get; set; }

        [StringLength(50)]
        public string? EmployeeDescription { get; set; }
    }
}

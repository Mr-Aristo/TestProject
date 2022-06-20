using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class EmployeeModel
    {
       
        public int EmployeeID { get; set; }

        
        public string? EmployeeName { get; set; }

       
        public string? EmployeeDescription { get; set; }

        public EmployeeModel() { }
        public EmployeeModel(Employee employee)
        {
            EmployeeID=employee.EmployeeID;
            EmployeeName=employee.EmployeeName;
            EmployeeDescription=employee.EmployeeDescription;
        }
        
        
    }

}

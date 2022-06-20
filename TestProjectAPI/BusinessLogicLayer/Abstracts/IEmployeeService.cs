using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstracts
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetAllEmployee();

        void CreateEmployee(EmployeeModel emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        List<EmployeeModel> GetEmployeeById(int id);
        List<EmployeeModel> GetEmployeeByName(string name);

    }
}

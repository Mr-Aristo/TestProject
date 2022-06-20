using BusinessLogicLayer.Abstracts;
using BusinessLogicLayer.Models;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        IUnitOfWork db;

        public EmployeeManager(IUnitOfWork db)
        {
            this.db = db;
        }

        public void CreateEmployee(EmployeeModel emp)
        {
            db.Employee.Add(new DataAccessLayer.Entities.Employee
            {
                EmployeeID = emp.EmployeeID,
                EmployeeName = emp.EmployeeName,
                EmployeeDescription = emp.EmployeeDescription,

            });
            db.Save();
        }

        public void DeleteEmployee(int id)
        {

            db.Employee.Remove(id);
            db.Save();
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            return db.Employee.GetAll()
                .Select(x => new EmployeeModel(x))
                .ToList();
        }

        public List<EmployeeModel> GetEmployeeById(int id)
        {
            return db.Employee.GetAll()
                .Where(x => x.EmployeeID == id)
                .Select(i => new EmployeeModel(i)).ToList();
        }

        public List<EmployeeModel> GetEmployeeByName(string name)
        {
            return db.Employee.GetAll()
                .Where(x => x.EmployeeName == name)
                .Select(i => new EmployeeModel(i))
                .ToList();
        }

        public void UpdateEmployee(Employee emp)
        {
            db.Employee.Update(emp);
            
        }

    }
}

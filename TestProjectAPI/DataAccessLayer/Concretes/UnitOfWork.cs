using DataAccessLayer.Abstracts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    
    public class UnitOfWork :IUnitOfWork
    {
        private readonly Context db;

        private EmployeeRepository? employee;
        public UnitOfWork()
        {
            db = new Context();
            
        }

    

        public IRepository<Employee> Employee
        {
            get
            {
                if (employee == null)
                    employee = new EmployeeRepository(db);
                return employee;
            }
        }

        public int Save()
        {
           return db.SaveChanges();
        }
    }
}

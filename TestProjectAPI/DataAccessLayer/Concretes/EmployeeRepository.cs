using DataAccessLayer.Abstracts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private Context db;

        public EmployeeRepository(Context context)
        {
            db = context;

        }
        public void Add(Employee entity)
        {
           db.Employees.Add(entity);
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetByID(int id)
        {
            return db.Employees.Find(id);
        }

        public void Remove(int id)
        {
            db.Employees.Remove(GetByID(id));
        }

        public void Update(Employee entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}

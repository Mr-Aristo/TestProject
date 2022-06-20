using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Context : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HOME-PC\\MSSQLSERVER01; database=EmployeeDb; integrated security=true;");
        }

        public virtual DbSet<Employee>? Employees { get; set; }
    }
}

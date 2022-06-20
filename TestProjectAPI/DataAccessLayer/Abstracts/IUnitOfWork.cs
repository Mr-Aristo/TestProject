using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employee { get;  }


        int Save();
    }
}

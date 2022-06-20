using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface IRepository<T> where T : class
    {
        T GetByID(int id);

        List<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Remove(int id);
    }
}



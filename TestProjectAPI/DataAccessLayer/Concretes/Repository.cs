using DataAccessLayer.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        private DbSet<T> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();

        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetByID(int id)
        {
            return _dbset.Find(id);
        }

        public void Remove(int id)
        {
            var entity = GetByID(id);
            _dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

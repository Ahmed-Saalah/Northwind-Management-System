using Microsoft.EntityFrameworkCore;
using Northwind_Management_System.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind_Management_System.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NorthwindContext _context;

        public Repository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}

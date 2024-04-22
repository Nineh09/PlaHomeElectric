using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GenericDao<T> where T : class
    {
        public HomeElectricContext _context;
        private GenericDao<T> _instance = null;
        public GenericDao<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenericDao<T>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        public GenericDao()
        {
            _context = new HomeElectricContext();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[]? includeProperties)
        {
            if (includeProperties == null)
            {
                return _context.Set<T>().ToList();
            }
            else
            {
                IQueryable<T> query = _context.Set<T>();

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return query.ToList();
            }
        }

        public virtual T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

using BusinessObject;
using DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HomeElectricContext _dbContext;
        private GenericDao<T> _dao;

        public GenericRepository(HomeElectricContext dbContext)
        {
            _dbContext = dbContext;
            _dao = new GenericDao<T>();
        }

        public void Add(T entity)
        {
            _dao.Add(entity);
        }

        public void Delete(T entity)
        {
            _dao.Delete(entity);
        }

        public List<T> GetAll(params Expression<Func<T, object>>[]? includeProperties)
        {
            return _dao.GetAll(includeProperties);
        }

        public T? GetById(int id)
        {
            return _dao.GetById(id);
        }

        public int Save()
        {
            return (_dao.Save());
        }

        public void Update(T entity)
        {
            _dao.Update(entity);
        }
    }
}

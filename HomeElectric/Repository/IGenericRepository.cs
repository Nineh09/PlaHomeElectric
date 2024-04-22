using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /*List<T> GetAll();*/
        List<T> GetAll(params Expression<Func<T, object>>[]? includeProperties);
        T? GetById(int id);
        void Delete(T entity);
        void Update(T entity);
        void Add(T entity);
        int Save();
    }
}

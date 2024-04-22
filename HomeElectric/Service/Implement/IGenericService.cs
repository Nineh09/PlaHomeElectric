using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[]? includeProperties);
        Task<T?> GetById(int id);
        Task Delete(T entity);
        Task Update(T entity);
        Task Add(T entity);
    }
}

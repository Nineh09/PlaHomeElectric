using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Category? GetCateName(string name);
    }
}

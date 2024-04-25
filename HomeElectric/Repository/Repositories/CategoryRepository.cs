using BusinessObject;
using DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private CategoryDAO _dao;
        public CategoryRepository()
        {
            _dao = new CategoryDAO();
        }
        public Category? GetCateName(string name)
        {
            return _dao.GetCateName(name);
        }
    }
}
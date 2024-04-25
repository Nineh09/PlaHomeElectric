using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryDAO : GenericDao<Category>
    {
        public Category? GetCateName(string name)
        {
            var cus = _context.Categories.FirstOrDefault(x => string.Compare(x.CategoryName.ToLower().Trim(), name.ToLower().Trim()) == 0);
            return cus;
        }
    }
}
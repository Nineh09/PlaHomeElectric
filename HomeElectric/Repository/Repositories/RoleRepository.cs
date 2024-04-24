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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private RoleDAO _dao;
        public RoleRepository()
        {
            _dao = new RoleDAO();
        }
    }
}

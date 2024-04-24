using BusinessObject;
using Repository.IRepository;
using Repository.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;


        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Task Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAll(params Expression<Func<Role, object>>[]? includeProperties)
        {
            try
            {
                return Task.FromResult(_roleRepository.GetAll());
            }
            catch
            {
                throw new Exception("Somethings has wrong, please refresh page!");
            }
        }

        public Task<Role?> GetById(int id)
        {
            try
            {
                return Task.FromResult(_roleRepository.GetById(id));
            }
            catch
            {
                throw new Exception("Somethings has wrong, please refresh page!");
            }
        }

        public Task Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

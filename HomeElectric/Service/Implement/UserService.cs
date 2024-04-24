using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(params Expression<Func<User, object>>[]? includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string email, string password)
        {
            User user = _userRepository.GetUser(email, password);
            return Task.FromResult(user);
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
       
    }
}

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
        public Task<bool> ExistByEmail(string email)
        {
            return Task.FromResult(_userRepository.CheckExistingEmail(email));
        }

        public Task<bool> ExistByTelephone(string phone)
        {
            return Task.FromResult(_userRepository.CheckExistingPhone(phone));
        }

        public Task<User> CreateUser(string name, string email, string password, string confirmPassword, string phone)
        {
            return Task.FromResult(_userRepository.CreateUser(new User(), name, email, password, confirmPassword, phone));
        }
    }
}

using BusinessObject;
using Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    var maxId = _userRepository.GetAll().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                    var nextId = maxId + 1;
                    var newUser = new User
                    {
                        //CustomerId = nextId,
                        FullName = entity.FullName,
                        PhoneNumber = entity.PhoneNumber,   
                        Email = entity.Email,
                        Password = entity.Password,
                        Address = entity.Address,
                        Description = entity.Description,
                        CreationDate = DateTime.Now, 
                    };
                    _userRepository.Add(newUser);
                    _userRepository.Save();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot create for this customer, please create again!");
            }
            return Task.CompletedTask;
        }

        public Task Delete(User entity)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var user = _userRepository.GetById(entity.Id);
                if (user != null)
                {
                    user.Status = 0;
                    user.DeletionDate = DateTime.Now;
                    _userRepository.Update(user);
                    _userRepository.Save();
                }
                scope.Complete();
            }
            return Task.CompletedTask;
        }

        public Task<List<User>> GetAll(params Expression<Func<User, object>>[]? includeProperties)
        {
            try
            {
                return Task.FromResult(_userRepository.GetAll());
            }
            catch
            {
                throw new Exception("Somethings has wrong, please refresh page!");
            }
        }

        public Task<User?> GetById(int id)
        {
            try
            {
                return Task.FromResult(_userRepository.GetById(id));
            }
            catch
            {
                throw new Exception("Somethings has wrong, please refresh page!");
            }
        }

        public Task<User> GetUser(string email, string password)
        {
            User user = _userRepository.GetUser(email, password);
            return Task.FromResult(user);
        }

        public Task Update(User entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {

                    var user = _userRepository.GetById(entity.Id);
                        
                    if (user != null)
                    {   
                        user.Password = entity.Password;
                        user.FullName = entity.FullName;
                        user.PhoneNumber = entity.PhoneNumber;
                        user.Address = entity.FullName;
                        user.Email = entity.Email;
                        user.ModificationDate = DateTime.Now;

                        _userRepository.Update(user);
                        _userRepository.Save();
                    }
                    scope.Complete();
                }
            }
            catch
            {
                throw new Exception("Cannot create for this customer, please create again!");
            }
            return Task.CompletedTask;
        }
       
    }
}

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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private UserDAO _dao;
        public UserRepository() 
        {
            _dao = new UserDAO();
        }

        public User? GetUser(string email, string password)
        {
            return _dao.GetUser(email, password);
        }
        //public bool CheckExistingEmail(string email)
        //{
        //    return _dbContext.Set<User>().Any(u => u.Email == email);
        //}

        //public bool CheckExistingPhone(string phone)
        //{
        //    return _dbContext.Set<User>().Any(u => u.PhoneNumber == phone);
        //}

        //public User CreateUser(User user, string name, string email, string password, string confirmPassword, string phone)
        //{
        //    if (password != confirmPassword)
        //    {
        //        throw new Exception("Password and confirm password do not match.");
        //    }

        //    if (CheckExistingEmail(email))
        //    {
        //        throw new Exception("Email already exists in the system.");
        //    }

        //    if (CheckExistingPhone(phone))
        //    {
        //        throw new Exception("Phone number already exists in the system.");
        //    }

        //    var newUser = new User
        //    {
        //        FullName = name,
        //        Email = email,
        //        Password = password,
        //        PhoneNumber = phone,
        //        RoleId = 3,
        //        Status = 1,
        //        CreationDate = DateTime.Now
        //    };

        //    _dbContext.Set<User>().Add(newUser);
        //    _dbContext.SaveChanges();

        //    return newUser;
        //}
    }
}

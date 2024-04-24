using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO : GenericDao< User>
    {
        public User GetUser(string email, string password)
        {
            return _context.Set<User>()
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public bool CheckExistingEmail(string email)
        {
            return _context.Set<User>().Any(u => u.Email == email);
        }

        public bool CheckExistingPhone(string phone)
        {
            return _context.Set<User>().Any(u => u.PhoneNumber == phone);
        }

        public User CreateUser(User user, string name, string email, string password, string confirmPassword, string phone)
        {
            if (password != confirmPassword)
            {
                throw new Exception("Password and confirm password do not match.");
            }

            if (CheckExistingEmail(email))
            {
                throw new Exception("Email already exists in the system.");
            }

            if (CheckExistingPhone(phone))
            {
                throw new Exception("Phone number already exists in the system.");
            }

            var newUser = new User
            {
                FullName = name,
                Email = email,
                Password = password,
                PhoneNumber = phone,
                RoleId = 3,
                Status = 1,
                CreationDate = DateTime.Now
            };

            _context.Set<User>().Add(newUser);
            _context.SaveChanges();

            return newUser;
        }
    }
}

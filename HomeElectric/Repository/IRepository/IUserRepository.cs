using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUser(string email, string password);
        bool CheckExistingEmail(string email);
        bool CheckExistingPhone(string phone);
        User CreateUser(User user, string name, string email, string password, string confirmPassword, string phone);
    }
}

using BusinessObject;
using Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetUser(string email, string password);
        Task<bool> ExistByEmail(string email);
        Task<bool> ExistByTelephone(string phone);
        Task<User> CreateUser(string name, string email, string password, string confirmPassword, string phone);
    }
}

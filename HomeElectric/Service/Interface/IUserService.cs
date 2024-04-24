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
        Task<User> GetUserByEmail(string email);
    }
}

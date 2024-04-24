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
        public User? GetUser(string email, string password);
        public User? GetUserByEmail(string email);
    }
}

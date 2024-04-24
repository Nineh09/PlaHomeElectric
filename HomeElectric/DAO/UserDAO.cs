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
    }
}

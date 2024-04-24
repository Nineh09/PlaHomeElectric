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
        public User? GetUser(string email, string password)
        {
            var cus = _context.Users.Where(x => string.Compare(x.Email!.ToLower().Trim(), email.ToLower().Trim()) == 0 &&
                                                    string.Compare(x.Password!.Trim(), password.Trim()) == 0).FirstOrDefault();
            return cus;
        }
        
    }
}

using BusinessObject;
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
        public UserRepository(HomeElectricContext dbContext) : base(dbContext)
        {
        }

        public User GetUser(string email, string password)
        {
            return _dbContext.Set<User>()
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}

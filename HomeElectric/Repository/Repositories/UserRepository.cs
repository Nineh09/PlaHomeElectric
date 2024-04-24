using BusinessObject;
using DAO;
using Repository.IRepository;

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
    }
}


using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class UsersService {

        private readonly UserDAO _userDAO;

        public UsersService(UserDAO userDAO){
            _userDAO = userDAO;
        }

        //GetAllUser
        public List<Users> GetAllUsers() {
            return _userDAO.GetAllUsers();
        }

        //GetUserById
        public Users? GetUserById(int id) {
            var user = _userDAO.GetUsersByID(id);
            if (user == null){
                throw new Exception ("User not found.");
            }
            return user;
        }
    }
} 
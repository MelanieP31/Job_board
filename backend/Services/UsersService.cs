
using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class UsersService
    {

        private readonly UserDAO _userDAO;

        public UsersService(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        //GetAllUser
        public List<Users> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        //GetUserById
        public Users? GetUserById(int id)
        {
            var user = _userDAO.GetUsersByID(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }

        public void AddUser(Users user)
        {
            _userDAO.CreateUser(user);
        }

        public void UpdateUser(int id, Users user)
        {
            _userDAO.UpdateUser(id, user);
        }

        public void DeleteUser(int id)
        {
            var user = _userDAO.GetUserByID(id);
            if (user != null)
            {
                throw new Exception("User not found");
            }
            else
            {
                _userDAO.DeleteUser(id);
            }
        }
    }
}
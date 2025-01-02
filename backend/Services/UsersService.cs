
using backend.Configuration;
using backend.Models;

namespace backend.Services
{
    public class UsersService
    {

        private readonly JobBoardContext _context;

        public UsersService(JobBoardContext context)
        {
            _context = context;
        }

        //GetAllUser
        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        //GetUserById
        public Users? GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, Users newUser)
        {
            var existingUser = _context.Users.FirstOrDefault(a => a.UserId == id);
            if (existingUser != null)
            {
                _context.Users.Update(newUser);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"User {id} not found");
            }
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
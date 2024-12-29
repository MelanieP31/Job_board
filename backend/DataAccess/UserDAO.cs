using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class UserDAO {

        private readonly JobBoardContext _context;

        //constructeur
        public UserDAO (JobBoardContext context) {
            _context = context;
        }

        //CRUD : Get all user
        public List<Users> GetAllUsers(){
            return _context.Users.ToList();
        }

        //CRUD : Get One User
        public Users? GetUsersByID(int id){
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        //CRUD : Create User
        public void CreateUser(Users user){
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //CRUD Update
        public void UpdateUser(Users user){
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        //CRUD Delete
        public void DeleteUser(int id){
            var user = GetUsersByID(id);
            if (user != null) {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        internal object GetUserByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
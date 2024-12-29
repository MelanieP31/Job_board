using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class AdminDAO {

        private readonly JobBoardContext _context;

        //constructeur
        public AdminDAO (JobBoardContext context) {
            _context = context;
        }

        //CRUD : Get One
        public Admins? GetAdminByID(int id){
            return _context.Admins.FirstOrDefault(u => u.AdminId == id);
        }
    }
}

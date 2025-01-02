using backend.Configuration;
using backend.Models;

namespace backend.Services
{
    public class AdminService{

        private readonly JobBoardContext _context;

        public AdminService(JobBoardContext context){

            _context = context;
        }

        public Admins? GetAdminById(int id){

            var admin = _context.Admins.FirstOrDefault(u => u.AdminId == id);
            
            if(admin == null) {
                throw new Exception ("Admin not found");
            }

            return admin;
        }
        
    }
}
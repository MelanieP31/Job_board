using System.Diagnostics;
using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class AdminService{

        private AdminDAO _AdminDAO;

        public AdminService(AdminDAO adminDAO){

            _AdminDAO = adminDAO;
        }

        public Admins? GetAdminByID(int id){

            var admin = _AdminDAO.GetAdminByID(id);
            
            if(admin == null) {
                throw new Exception ("Admin not found");
            }

            return admin;
        }
        
    }
}
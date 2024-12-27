using backend.Data;
using backend.Models;

namespace backend.DataAccess 
{
    public class ApplicationsDAO {

        private readonly JobBoardContext _context; 

        public ApplicationsDAO (JobBoardContext context){
            _context = context; 
        }

        //CRUD Get All Application
        public List<Applications> GetAllApplications(){
            return _context.Applications.ToList();
        }

        //CRUD : Get one application
        public Applications? GetApplicationsById(int id){
            return _context.Applications.FirstOrDefault(u => u.AppId == id);
        }

        // CRUD Create an application
        public void AddApplication(Applications applications){
            _context.Applications.Add(applications);
            _context.SaveChanges();
        }

        //CRUD Update une application
        public void UpdateApplication(Applications applications){
            _context.Applications.Update(applications);
            _context.SaveChanges();
        }

        //CRUD Delete une application
        public void DeleteApplication(int id){
            var application = GetApplicationsById(id);
            if (application != null) {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }
    }
}
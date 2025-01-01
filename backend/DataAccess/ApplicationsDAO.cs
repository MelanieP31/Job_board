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

        public void UpdateApplicationStatus(int applicationId, string newStatus) {
            var existingApplication = _context.Applications.FirstOrDefault(a => a.AppId == applicationId);
            if (existingApplication != null) {
                existingApplication.Status = newStatus; 
                _context.SaveChanges();
            } else {
                throw new Exception("Application not found.");
            }
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
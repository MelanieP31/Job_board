using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class ApplicationsService
    {

        private readonly JobBoardContext _context;

        public ApplicationsService(JobBoardContext context)
        {
            _context = context;
        }

        public List<Applications> GetAllApplications()
        {
            return _context.Applications.ToList();
        }

        public Applications? GetApplicationsById(int id)
        {
            var applications = _context.Applications.FirstOrDefault(u => u.AppId == id);
            if (applications != null)
            {
                throw new Exception("Applications not found");
            }
            return applications;
        }

        public void AddApplication(Applications applications)
        {
            _context.Applications.Add(applications);
            _context.SaveChanges();
        }

        public void UpdateApplication(int id, string newStatus)
        {
            var existingApplication = _context.Applications.FirstOrDefault(a => a.AppId == id);
            if (existingApplication != null)
            {
                existingApplication.Status = newStatus;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Application not found.");
            }
        }

        public void DeleteApplication(int id)
        {
            var application = GetApplicationsById(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }
    }
}
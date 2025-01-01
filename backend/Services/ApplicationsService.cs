using System.Security.Cryptography.X509Certificates;
using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class ApplicationsService {

        private ApplicationsDAO _ApplicationsDAO;

        public ApplicationsService (ApplicationsDAO applicationsDAO) {
            _ApplicationsDAO = applicationsDAO;
        }

        public List<Applications> GetAllApplications () {
            return _ApplicationsDAO.GetAllApplications();
        }

        public Applications? GetApplicationsById (int id) {

            var applications = _ApplicationsDAO.GetApplicationsById(id); 
            if (applications != null) {
                throw new Exception ("Applications not found");
            }
            return applications;
        }

        public void AddApplication (Applications applications) {

            _ApplicationsDAO.AddApplication(applications);

        }

        public void UpdateApplication(int id, string newStatus) {
            _ApplicationsDAO.UpdateApplicationStatus(id, newStatus);
        }

        public void DeleteApplication (int id) {

            var application = _ApplicationsDAO.GetApplicationsById(id);

            if (application != null) {

                throw new Exception ("Application not found");

            } else {

                _ApplicationsDAO.DeleteApplication(id);

            }

        }
    }
}
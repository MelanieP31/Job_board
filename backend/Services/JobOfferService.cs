using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class JobOfferService {

        private JobOfferDAO _jobOfferDAO;

        public JobOfferService (JobOfferDAO jobOfferDAO) {
            _jobOfferDAO = jobOfferDAO;
        }

        public List<Joboffer> GetAllJobOffer () {
            return _jobOfferDAO.GetAllJobOffer();
        }

        public Joboffer? GetJobOfferById (int id) {

            var jobOffer = _jobOfferDAO.GetJobOfferByID(id); 
            if (jobOffer != null) {
                throw new Exception ("JobOffer not found");
            }
            return jobOffer;
        }

        public void AddJobOffer (Joboffer jobOffer) {

            _jobOfferDAO.CreateJobOffer(jobOffer);

        }

        public void UpdateJobOffer (Joboffer jobOffer) {

            _jobOfferDAO.UpdateJobOffer(jobOffer); 

        }

        public void DeleteJobOffer (int id) {

            var jobOffer = _jobOfferDAO.GetJobOfferByID(id);

            if (jobOffer != null) {

                throw new Exception ("JobOffer not found");

            } else {

                _jobOfferDAO.DeleteJobOffer(id);

            }

        }
    }
}
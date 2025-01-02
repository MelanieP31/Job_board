using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class JobOfferService
    {

        private readonly JobBoardContext _context;

        public JobOfferService(JobBoardContext context)
        {
            _context = context;
        }

        public List<Joboffer> GetAllJobOffer()
        {
            return _context.Joboffers.ToList();
        }

        public Joboffer? GetJobOfferById(int id)
        {
            var jobOffer = _context.Joboffers.FirstOrDefault(u => u.JobId == id);
            if (jobOffer == null)
            {
                throw new Exception("JobOffer not found");
            }
            return jobOffer;
        }

        public void AddJobOffer(Joboffer jobOffer)
        {
            _context.Joboffers.Add(jobOffer);
            _context.SaveChanges();
        }

        public void DeleteJobOffer(int id)
        {
            var Joboffer = GetJobOfferById(id);
            if (Joboffer != null)
            {
                _context.Joboffers.Remove(Joboffer);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("JobOffer not found");
            }
        }
    }
}
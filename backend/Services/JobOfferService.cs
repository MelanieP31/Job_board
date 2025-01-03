using AutoMapper;
using backend.Configuration;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class JobOfferService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public JobOfferService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Joboffer> GetAllJobOffer()
        {
            return _context.Joboffers
                .Include(j => j.Company)
                .Include(j => j.Applications)
                .ToList();
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
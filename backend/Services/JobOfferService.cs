using AutoMapper;
using backend.Configuration;
using backend.DTO;
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

        public List<JobofferDTO> GetAllJobOffer()
        {
            var jobOffer = _context.Joboffer
                .Include(j => j.Company)
                .Include(j => j.Applications)
                .ThenInclude(a => a.User)
                .ToList();
            return _mapper.Map<List<JobofferDTO>>(jobOffer);
        }

        public JobofferDTO? GetJobOfferById (int id)
        {
            var jobOffer = _context.Joboffer
                .Include(j => j.Company)
                .Include(j => j.Applications)
                .FirstOrDefault(u => u.JobId == id);
            if (jobOffer == null)
            {
                throw new Exception("JobOffer not found");
            }
            return _mapper.Map<JobofferDTO>(jobOffer);
        }

        public void AddJobOffer(JobofferDTO jobOfferDTO)
        {
            var jobOffer = _mapper.Map<Joboffer>(jobOfferDTO);
            _context.Joboffer.Add(jobOffer);
            _context.SaveChanges();
        }

        public void DeleteJobOffer(int id)
        {
            var Joboffer = _context.Joboffer.FirstOrDefault(u => u.JobId == id);
            if (Joboffer != null)
            {
                _context.Joboffer.Remove(Joboffer);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("JobOffer not found");
            }
        }
    }
}
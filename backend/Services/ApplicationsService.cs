using AutoMapper;
using backend.Configuration;
using backend.DTO;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ApplicationsService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public ApplicationsService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public List<ApplicationsDTO> GetAllApplications()
        {
            var applications = _context.Applications
            .Include(a => a.User)
            .Include(a => a.JobOffer)
            .ToList();

            return _mapper.Map<List<ApplicationsDTO>>(applications);
        }

        public ApplicationsDTO GetApplicationsById(int id)
        {
            var applications = _context.Applications
                .Include(a => a.User)
                .Include(a => a.JobOffer)
                .FirstOrDefault(u => u.AppId == id);

            if (applications == null)
            {
                throw new Exception("Applications not found");
            }

            return _mapper.Map<ApplicationsDTO>(applications);
        }

        public void AddApplication(ApplicationsDTO applicationDTO)
        {
            var application = _mapper.Map<Applications>(applicationDTO);
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public void UpdateApplication(int id, string newStatus)
        {
            var existingApplication = _context.Applications.FirstOrDefault(a => a.AppId == id);
            if (existingApplication != null)
            {
                throw new Exception("Application not found.");
            }
         
            existingApplication.Status = newStatus;
            _context.SaveChanges();        
            
        }

        public void DeleteApplication(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.AppId == id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }
    }
}
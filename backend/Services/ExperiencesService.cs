using AutoMapper;
using backend.Configuration;
using backend.DTO;
using backend.Models;

namespace backend.Services
{
    public class ExperiencesService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public ExperiencesService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExperiencesDTO> GetAllExperiences()
        {
            var experiences = _context.Experiences.ToList();
            return _mapper.Map<List<ExperiencesDTO>>(experiences);
        }

        public ExperiencesDTO? GetExperiencesById(int id)
        {
            var experiences = _context.Experiences.FirstOrDefault(u => u.ExperienceId == id);
            if (experiences == null)
            {
                throw new Exception("Experiences not found");
            }
            return _mapper.Map<ExperiencesDTO>(experiences);
        }

        public void AddExperiences(ExperiencesDTO ExperiencesDTO)
        {
            var experiences = _mapper.Map<Experiences>(ExperiencesDTO);
            _context.Experiences.Add(experiences);
            _context.SaveChanges();
        }

        public void UpdateExperiences(int id, Experiences newExperiences)
        {
            var existingExperiences = _context.Experiences.FirstOrDefault(a => a.ExperienceId == id);
            if (existingExperiences != null)
            {
                _context.Experiences.Update(newExperiences);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Experience {id} not found");
            }
        }

        public void DeleteExperiences(int id)
        {
            var experiences = _context.Experiences.FirstOrDefault(u => u.ExperienceId == id);
            if (experiences != null)
            {
                _context.Experiences.Remove(experiences);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Experiences not found");
            }
        }
    }
}
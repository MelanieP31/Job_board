using backend.Data;
using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class ExperiencesService
    {

        private readonly JobBoardContext _context;

        public ExperiencesService(JobBoardContext context)
        {
            _context = context;
        }

        public List<Experiences> GetAllExperiences()
        {
            return _context.Experiences.ToList();
        }

        public Experiences? GetExperiencesById(int id)
        {
            var experiences = _context.Experiences.FirstOrDefault(u => u.ExperienceId == id);
            if (experiences == null)
            {
                throw new Exception("Experiences not found");
            }
            return experiences;
        }

        public void AddExperiences(Experiences experiences)
        {
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
            var experiences = GetExperiencesById(id);
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
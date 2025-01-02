using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class ExperiencesDAO {

        private readonly JobBoardContext _context;

        //constructeur
        public ExperiencesDAO (JobBoardContext context) {
            _context = context;
        }

        //CRUD : Get all
        public List<Experiences> GetAllExperiences(){
            return _context.Experiences.ToList();
        }

        //CRUD : Get One
        public Experiences? GetExperiencesByID(int id){
            return _context.Experiences.FirstOrDefault(u => u.ExperienceId == id);
        }

        //CRUD : Create
        public void CreateExperiences(Experiences experiences){
            _context.Experiences.Add(experiences);
            _context.SaveChanges();
        }

        //CRUD Update
        public void UpdateExperiences(int id, Experiences newExperiences){
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

        //CRUD Delete
        public void DeleteExperiences(int id){
            var experiences = GetExperiencesByID(id);
            if (experiences != null) {
                _context.Experiences.Remove(experiences);
                _context.SaveChanges();
            }
        }

    }
}
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
        public void UpdateExperiences(Experiences experiences){
            _context.Experiences.Update(experiences);
            _context.SaveChanges();
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
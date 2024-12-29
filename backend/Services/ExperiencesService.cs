using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class ExperiencesService {

        private ExperiencesDAO _experiencesDAO;

        public ExperiencesService (ExperiencesDAO experiencesDAO) {
            _experiencesDAO = experiencesDAO;
        }

        public List<Experiences> GetAllExperiences () {
            return _experiencesDAO.GetAllExperiences();
        }

        public Experiences? GetExperiencesById (int id) {

            var experiences = _experiencesDAO.GetExperiencesByID(id); 
            if (experiences != null) {
                throw new Exception ("Experiences not found");
            }
            return experiences;
        }

        public void AddExperiences (Experiences experiences) {

            _experiencesDAO.CreateExperiences(experiences);

        }

        public void UpdateExperiences (Experiences experiences) {

            _experiencesDAO.UpdateExperiences(experiences); 

        }

        public void DeleteExperiences (int id) {

            var experiences = _experiencesDAO.GetExperiencesByID(id);

            if (experiences != null) {

                throw new Exception ("Experiences not found");

            } else {

                _experiencesDAO.DeleteExperiences(id);

            }

        }
    }
}
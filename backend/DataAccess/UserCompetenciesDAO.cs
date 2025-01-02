

using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class UserCompetenciesDAO {

        private readonly JobBoardContext _context;

        public UserCompetenciesDAO (JobBoardContext context){
            _context = context;
        }

        // Get all competencies of one user
        public List<Competencies> GetComptenciesByUserId(int userId){
            return [.. _context.UserCompetencies.Where(c => c.UserId == userId).Select(c => c.Competency)];
        }

        //Add competencies to a user
        public void AddCompetencyToUserId(int userId, int competency_id){

            UserCompetencies userCompetencies = new UserCompetencies();
            userCompetencies.UserId = userId;
            userCompetencies.CompetencyId = competency_id;

            _context.UserCompetencies.Add(userCompetencies);
            _context.SaveChanges();
        }

        //Delete competency from one user
        public void DeleteCompetencyByUserId(int userId, int competency_id) {

            var competency = _context.UserCompetencies
                .FirstOrDefault(c => c.UserId == userId && c.CompetencyId == competency_id);

            if (competency!= null){
                _context.UserCompetencies.Remove(competency);
                _context.SaveChanges();
            }
        }
    }
}
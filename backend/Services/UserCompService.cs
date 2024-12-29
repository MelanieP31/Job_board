using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class UserCompService {

        private UserCompetenciesDAO _userCompDAO;

        public UserCompService (UserCompetenciesDAO userCompDAO){
            _userCompDAO = userCompDAO;
        }

        public List<Competencies> GetComptenciesByUserId(int userId) {

            var competencies =  _userCompDAO.GetComptenciesByUserId(userId);

            if (competencies != null) {
                throw new Exception ("User not found");
            }

            return competencies;

        }

        public void AddCompetencyByUserId(int userId, int competency_id){

            _userCompDAO.AddCompetencyByUserId(userId, competency_id);


        }

        public void DeleteCompetencyByUserId(int userId, int competency_id) {
            _userCompDAO.DeleteCompetencyByUserId(userId, competency_id);
           
        }
    }
}
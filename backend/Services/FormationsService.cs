using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class FormationsService {

        private FormationsDAO _formationDAO;

        public FormationsService (FormationsDAO formationsDAO) {
            _formationDAO = formationsDAO;
        }

        public List<Formations> GetAllFormations () {
            return _formationDAO.GetAllFormations();
        }

        public Formations? GetFormationsById (int id) {

            var formations = _formationDAO.GetFormationsByID(id); 
            if (formations != null) {
                throw new Exception ("Formations not found");
            }
            return formations;
        }

        public void AddFormations (Formations formations) {

            _formationDAO.CreateFormations(formations);

        }

        public void UpdateFormations (Formations formations) {

            _formationDAO.UpdateFormations(formations); 

        }

        public void DeleteFormations (int id) {

            var formations = _formationDAO.GetFormationsByID(id);

            if (formations != null) {

                throw new Exception ("Formations not found");

            } else {

                _formationDAO.DeleteFormations(id);

            }

        }
    }
}
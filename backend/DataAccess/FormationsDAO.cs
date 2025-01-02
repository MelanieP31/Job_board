using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class FormationsDAO
    {

        private readonly JobBoardContext _context;

        //constructeur
        public FormationsDAO(JobBoardContext context)
        {
            _context = context;
        }

        //CRUD : Get all
        public List<Formations> GetAllFormations()
        {
            return _context.Formations.ToList();
        }

        //CRUD : Get One
        public Formations? GetFormationsByID(int id)
        {
            return _context.Formations.FirstOrDefault(u => u.FormationId == id);
        }

        //CRUD : Create
        public void CreateFormations(Formations formation)
        {
            _context.Formations.Add(formation);
            _context.SaveChanges();
        }

        //CRUD Update
        public void UpdateFormations(int id, Formations newFormations)
        {
            var existingFormations = _context.Formations.FirstOrDefault(a => a.FormationId == id);
            if (existingFormations != null)
            {
                _context.Formations.Update(newFormations);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Formation {id} not found");
            }
        }

        //CRUD Delete
        public void DeleteFormations(int id)
        {
            var formations = GetFormationsByID(id);
            if (formations != null)
            {
                _context.Formations.Remove(formations);
                _context.SaveChanges();
            }
        }

    }
}
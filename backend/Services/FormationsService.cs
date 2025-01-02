using backend.Configuration;
using backend.Models;

namespace backend.Services
{
    public class FormationsService
    {

        private readonly JobBoardContext _context;

        public FormationsService(JobBoardContext context)
        {
            _context = context;
        }

        public List<Formations> GetAllFormations()
        {
            return _context.Formations.ToList();
        }

        public Formations? GetFormationsById(int id)
        {

            var formations = _context.Formations.FirstOrDefault(u => u.FormationId == id);
            if (formations == null)
            {
                throw new Exception("Formations not found");
            }
            return formations;
        }

        public void AddFormations(Formations formation)
        {
            _context.Formations.Add(formation);
            _context.SaveChanges();
        }

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

        public void DeleteFormations(int id)
        {
            var formations = GetFormationsById(id);
            if (formations != null)
            {
                _context.Formations.Remove(formations);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Formations not found");
            }
        }
    }
}
using backend.Configuration;
using backend.Models;

namespace backend.Services
{
    public class UserCompService
    {

        private readonly JobBoardContext _context;

        public UserCompService(JobBoardContext context)
        {
            _context = context;
        }

        public List<Competencies?> GetComptenciesByUserId(int userId)
        {
            var competencies = _context.UserCompetencies.Where(c => c.UserId == userId).Select(c => c.Competency).ToList();
            if (competencies == null)
            {
                throw new Exception("User not found");
            }
            return competencies;
        }

        public void AddCompetencyByUserId(int userId, int competency_id)
        {
            UserCompetencies userCompetencies = new UserCompetencies();
            userCompetencies.UserId = userId;
            userCompetencies.CompetencyId = competency_id;

            _context.UserCompetencies.Add(userCompetencies);
            _context.SaveChanges();
        }

        public void DeleteCompetencyByUserId(int userId, int competency_id)
        {
            var competency = _context.UserCompetencies
                 .FirstOrDefault(c => c.UserId == userId && c.CompetencyId == competency_id);
            if (competency != null)
            {
                _context.UserCompetencies.Remove(competency);
                _context.SaveChanges();
            }
        }
    }
}
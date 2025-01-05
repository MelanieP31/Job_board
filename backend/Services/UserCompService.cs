using AutoMapper;
using backend.Configuration;
using backend.Models;
using backend.DTO;

namespace backend.Services
{
    public class UserCompService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public UserCompService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CompetenciesDTO> GetComptenciesByUserId(int userId)
        {
            var competencies = _context.User_Competencies.Where(c => c.UserId == userId).Select(c => c.Competency).ToList();
            if (competencies == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<List<CompetenciesDTO>>(competencies);
        }

        public void AddCompetencyByUserId(int userId, int competency_id)
        {
            UserCompetencies userCompetencies = new UserCompetencies();
            userCompetencies.UserId = userId;
            userCompetencies.CompetencyId = competency_id;

            _context.User_Competencies.Add(userCompetencies);
            _context.SaveChanges();
        }

        public void DeleteCompetencyByUserId(int userId, int competency_id)
        {
            var competency = _context.User_Competencies
                 .FirstOrDefault(c => c.UserId == userId && c.CompetencyId == competency_id);
            if (competency != null)
            {
                _context.User_Competencies.Remove(competency);
                _context.SaveChanges();
            }
        }
    }
}
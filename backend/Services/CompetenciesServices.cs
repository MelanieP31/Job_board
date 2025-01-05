using AutoMapper;
using backend.Configuration;
using backend.DTO;
using backend.Models;

namespace backend.Services{
    public class CompetenciesServices{
        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public CompetenciesServices(JobBoardContext context, IMapper mapper){
            _context = context;
            _mapper = mapper; 
        }

        public List<CompetenciesDTO> GetAllCompetencies()
        {
            var competencies = _context.Competencies.ToList();
            return _mapper.Map<List<CompetenciesDTO>>(competencies);
        }

        public CompetenciesDTO GetCompetencyById(int id)
        {
            var competency = _context.Competencies.FirstOrDefault(c => c.CompetencyId == id);
            if (competency == null)
            {
                throw new Exception("Competency not found");
            }
            return _mapper.Map<CompetenciesDTO>(competency);
        }

        public void AddCompetency(CompetenciesDTO competencyDTO)
        {
            var competency = _mapper.Map<Competencies>(competencyDTO);
            _context.Competencies.Add(competency);
            _context.SaveChanges();
        }

        public void DeleteCompetency(int id)
        {
            var competency = _context.Competencies.FirstOrDefault(c => c.CompetencyId == id);
            if (competency != null)
            {
                _context.Competencies.Remove(competency);
                _context.SaveChanges();
            }
        }






    }
}
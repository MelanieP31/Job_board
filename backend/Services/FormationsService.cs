using AutoMapper;
using backend.Configuration;
using backend.DTO;
using backend.Models;

namespace backend.Services
{
    public class FormationsService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public FormationsService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<FormationsDTO> GetAllFormations()
        {
            var formation = _context.Formations.ToList();
            return _mapper.Map<List<FormationsDTO>>(formation);
        }

        public FormationsDTO? GetFormationsById(int id)
        {

            var formations = _context.Formations.FirstOrDefault(u => u.FormationId == id);
            if (formations == null)
            {
                throw new Exception("Formations not found");
            }
            return _mapper.Map<FormationsDTO>(formations);
        }

        public void AddFormations(FormationsDTO FormationDTO)
        {
            var formations = _mapper.Map<Formations>(FormationDTO);
            _context.Formations.Add(formations);
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
            var formations = _context.Formations.FirstOrDefault(u => u.FormationId == id);
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
using AutoMapper;
using backend.Configuration;
using backend.Models;
using backend.DTO;

namespace backend.Services
{
    public class CompaniesService
    {

        private readonly JobBoardContext _context;
        private readonly IMapper _mapper;

        public CompaniesService(JobBoardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CompaniesDTO> GetAllCompanies()
        {
            var companies = _context.Companies.ToList();
            return _mapper.Map<List<CompaniesDTO>>(companies);
        }

        public CompaniesDTO? GetCompaniesById(int id)
        {
            var companies = _context.Companies.FirstOrDefault(u => u.CompanyId == id);
            if (companies == null)
            {
                throw new Exception("Companies not found");
            }
            return _mapper.Map<CompaniesDTO>(companies);
        }

        public void AddCompanies(CompaniesDTO CompanyDTO)
        {
            var company = _mapper.Map<Companies>(CompanyDTO);
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void UpdateCompanie(int id, Companies newCompany)
        {
            var existingCompanies = _context.Companies.FirstOrDefault(a => a.CompanyId == id);
            if (existingCompanies != null)
            {
                _context.Companies.Update(newCompany);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Company {id} not found");
            };
        }

        public void DeleteCompanies(int id)
        {
            var company = _context.Companies.FirstOrDefault(a => a.CompanyId == id);;
            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Companies not found");

            }
        }
    }
}
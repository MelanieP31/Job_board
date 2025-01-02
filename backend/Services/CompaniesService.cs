using backend.Configuration;
using backend.Models;

namespace backend.Services
{
    public class CompaniesService {

        private readonly JobBoardContext _context;

        public CompaniesService (JobBoardContext context) {
            _context = context;
        }

        public List<Companies> GetAllCompanies () {
            return _context.Companies.ToList();
        }

        public Companies? GetCompaniesById (int id) {
            var companies = _context.Companies.FirstOrDefault(u => u.CompanyId == id);
            if (companies == null) {
                throw new Exception ("Companies not found");
            }
            return companies;
        }

        public void AddCompanies (Companies company) {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void UpdateCompanie (int id, Companies newCompany) {
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

        public void DeleteCompanies (int id) {
            var company = GetCompaniesById(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            } else {
                throw new Exception ("Companies not found");

            }
        }
    }
}
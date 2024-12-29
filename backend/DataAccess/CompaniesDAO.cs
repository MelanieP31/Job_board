using backend.Data;
using backend.Models;

namespace backend.DataAccess
{
    public class CompaniesDAO {

        private readonly JobBoardContext _context;

        //constructeur
        public CompaniesDAO (JobBoardContext context) {
            _context = context;
        }

        //CRUD : Get all user
        public List<Companies> GetAllCompanies(){
            return _context.Companies.ToList();
        }

        //CRUD : Get One User
        public Companies? GetCompaniesByID(int id){
            return _context.Companies.FirstOrDefault(u => u.CompanyId == id);
        }

        //CRUD : Create User
        public void CreateCompanies(Companies company){
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        //CRUD Update
        public void UpdateCompanies(Companies company){
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        //CRUD Delete
        public void DeleteCompanies(int id){
            var company = GetCompaniesByID(id);
            if (company != null) {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }
    }
}
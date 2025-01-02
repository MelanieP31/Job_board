using System.Security.Cryptography.X509Certificates;
using backend.DataAccess;
using backend.Models;

namespace backend.Services
{
    public class CompaniesService {

        private CompaniesDAO _CompaniesDAO;

        public CompaniesService (CompaniesDAO companiesDAO) {
            _CompaniesDAO = companiesDAO;
        }

        public List<Companies> GetAllCompanies () {
            return _CompaniesDAO.GetAllCompanies();
        }

        public Companies? GetCompaniesById (int id) {

            var companies = _CompaniesDAO.GetCompaniesByID(id); 
            if (companies != null) {
                throw new Exception ("Companies not found");
            }
            return companies;
        }

        public void AddCompanies (Companies companies) {

            _CompaniesDAO.CreateCompanies(companies);

        }

        public void UpdateCompanie (int id, Companies newCompany) {

            _CompaniesDAO.UpdateCompanies(id, newCompany); 

        }

        public void DeleteCompanies (int id) {

            var companies = _CompaniesDAO.GetCompaniesByID(id);

            if (companies != null) {

                throw new Exception ("Companies not found");

            } else {

                _CompaniesDAO.DeleteCompanies(id);

            }

        }
    }
}
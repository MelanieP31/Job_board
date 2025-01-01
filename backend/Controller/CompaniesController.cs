using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("/api/companies")]
    public class CompaniesController : ControllerBase {
        private readonly CompaniesService _compService;

        public CompaniesController(CompaniesService compService){
            _compService = compService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllCompanies(){
            var companies = _compService.GetAllCompanies();
            return Ok(companies);
        }
    }
}
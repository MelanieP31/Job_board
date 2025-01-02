using backend.Models;
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

        [HttpGet("id/{id}")]
        public IActionResult GetCompaniesById(int id)
        {

            var companies = _compService.GetCompaniesById(id);

            if (companies != null)
            {
                return Ok(companies);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddCompanies([FromBody] Companies comp)
        {

            if (comp == null)
            {
                return BadRequest("Invalid data for company");
            }

            _compService.AddCompanies(comp);

            return CreatedAtAction(nameof(GetCompaniesById), new { id = comp.CompanyId }, comp); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompanies(int id, [FromBody] Companies newCompanies)
        {
            _compService.UpdateCompanie(id, newCompanies);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompanies(int id)
        {
            var companies = _compService.GetCompaniesById(id);
            if (companies == null)
            {
                return NotFound($"Companies {id} not found.");
            }

            _compService.DeleteCompanies(id);
            return NoContent(); // 204 
        }
    }
}
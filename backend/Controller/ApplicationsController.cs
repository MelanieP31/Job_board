using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.DTO;

// Voir toute les applications, 
//selectionner une application, 
//ajouter une application, 
// supprimer une application, 
// modifier le statut
namespace backend.Controller
{

    [Route("/api/applications")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationsService _appService;

        public ApplicationsController(ApplicationsService appService)
        {
            _appService = appService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllApplications()
        {
            var applications = _appService.GetAllApplications();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public IActionResult GetApplicationsById(int id)
        {
            var applications = _appService.GetApplicationsById(id);
            if (applications != null)
            {
                return Ok(applications);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddApplications([FromBody] ApplicationsDTO applicationsDTO)
        {

            if (applicationsDTO == null)
            {
                return BadRequest("Invalid data for applications");
            }

            _appService.AddApplication(applicationsDTO);

            return CreatedAtAction(nameof(GetApplicationsById), new { id = applicationsDTO.AppId }, applicationsDTO); //201 --> + fournit url avec GetApplicationById et l'Id pour voir l'app créer.
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplication(int id, [FromBody] string newStatus)
        {
            _appService.UpdateApplication(id, newStatus);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplication(int id)
        {
            var application = _appService.GetApplicationsById(id);
            if (application == null)
            {
                return NotFound($"Application with ID {id} not found.");
            }

            _appService.DeleteApplication(id);
            return NoContent(); // 204 
        }

    }
}
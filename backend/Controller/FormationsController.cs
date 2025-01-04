using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("/api/formations")]
    public class FormationsController : ControllerBase {
        private readonly FormationsService _formService;

        public FormationsController(FormationsService formService){
            _formService = formService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllFormations(){
            var Formations = _formService.GetAllFormations();
            return Ok(Formations);
        }

        [HttpGet("{id}")]
        public IActionResult GetFormationsById(int id)
        {

            var Formations = _formService.GetFormationsById(id);

            if (Formations!= null)
            {
                return Ok(Formations);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddFormations([FromBody] FormationsDTO formDTO)
        {
            if (formDTO == null)
            {
                return BadRequest("Invalid data for Formations");
            }
            _formService.AddFormations(formDTO);
            return CreatedAtAction(nameof(GetFormationsById), new { id = formDTO.FormationId }, formDTO); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFormations(int id, [FromBody] Formations newFormations)
        {
            _formService.UpdateFormations(id, newFormations);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFormations(int id)
        {
            var Formations = _formService.GetFormationsById(id);
            if (Formations == null)
            {
                return NotFound($"Formations {id} not found.");
            }

            _formService.DeleteFormations(id);
            return NoContent(); // 204 
        }
    }
}
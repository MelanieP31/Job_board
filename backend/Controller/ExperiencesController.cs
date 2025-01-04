using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("/api/experiences")]
    public class ExperiencesController : ControllerBase {
        private readonly ExperiencesService _expService;

        public ExperiencesController(ExperiencesService expService){
            _expService = expService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllExperiences(){
            var Experiences = _expService.GetAllExperiences();
            return Ok(Experiences);
        }

        [HttpGet("{id}")]
        public IActionResult GetExperiencesById(int id)
        {

            var Experiences = _expService.GetExperiencesById(id);

            if (Experiences!= null)
            {
                return Ok(Experiences);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddExperiences([FromBody] ExperiencesDTO expDTO)
        {

            if (expDTO == null)
            {
                return BadRequest("Invalid data for Experiences");
            }

            _expService.AddExperiences(expDTO);

            return CreatedAtAction(nameof(GetExperiencesById), new { id = expDTO.ExperienceId }, expDTO); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExperiences(int id, [FromBody] Experiences newExperiences)
        {
            _expService.UpdateExperiences(id, newExperiences);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExperiences(int id)
        {
            var Experiences = _expService.GetExperiencesById(id);
            if (Experiences == null)
            {
                return NotFound($"Experiences {id} not found.");
            }

            _expService.DeleteExperiences(id);
            return NoContent(); // 204 
        }
    }
}
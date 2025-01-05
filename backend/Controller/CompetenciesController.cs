using backend.DTO;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("/api/competencies")]
    public class CompetenciesController : ControllerBase
    {
        private readonly CompetenciesServices _competenciesService;

        public CompetenciesController(CompetenciesServices competenciesService)
        {
            _competenciesService = competenciesService;
        }

        [HttpGet]
        public IActionResult GetAllCompetencies()
        {
            var competencies = _competenciesService.GetAllCompetencies();
            return Ok(competencies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompetencyById(int id)
        {
            try
            {
                var competency = _competenciesService.GetCompetencyById(id);
                return Ok(competency);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCompetency([FromBody] CompetenciesDTO competencyDTO)
        {
            if (competencyDTO == null)
            {
                return BadRequest("Invalid data for Competency");
            }
            _competenciesService.AddCompetency(competencyDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompetency(int id)
        {
            try
            {
                _competenciesService.DeleteCompetency(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

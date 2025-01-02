using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{

    [Route("/api/usercomp")]
    public class UserCompController : ControllerBase
    {
        private readonly UserCompService _ucompService;

        public UserCompController(UserCompService ucompService)
        {
            _ucompService = ucompService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCompetenciesByUserId(int userId) {
            var userComp = _ucompService.GetComptenciesByUserId(userId);
            return Ok(userComp);
        }

        [HttpPost]
        public IActionResult AddCompetencyByUserId (int userId, int competency_id) {

            _ucompService.AddCompetencyByUserId(userId,competency_id);
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteCompetencyByUserId(int userId, int competency_id) {

            _ucompService.DeleteCompetencyByUserId(userId, competency_id);
            return Ok();

        }


    }
}

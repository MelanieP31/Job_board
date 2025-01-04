using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller{

    [Route("/api/joboffers")]
    public class JobOfferController : ControllerBase {
        private readonly JobOfferService _jobService;

        public JobOfferController(JobOfferService jobService){
            _jobService = jobService;
        }

        //GET all 
        [HttpGet]
        public IActionResult GetAllJobOffer(){
            var Job = _jobService.GetAllJobOffer();
            return Ok(Job);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobOfferById(int id)
        {
            var JobOffer = _jobService.GetJobOfferById(id);
            if (JobOffer== null)
            {
                return NotFound();
            }
            
            return Ok(JobOffer);
        }

        [HttpPost]
        public IActionResult AddJobOffer([FromBody] JobofferDTO jobDTO)
        {
            if (jobDTO == null)
            {
                return BadRequest("Invalid data for JobOffer");
            }
            _jobService.AddJobOffer(jobDTO);
            return CreatedAtAction(nameof(GetJobOfferById), new { id = jobDTO.JobId }, jobDTO); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJobOffer(int id)
        {
            var JobOffer = _jobService.GetJobOfferById(id);
            if (JobOffer == null)
            {
                return NotFound($"JobOffer {id} not found.");
            }

            _jobService.DeleteJobOffer(id);
            return NoContent(); // 204 
        }
    }
}
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

        [HttpGet("id/{id}")]
        public IActionResult GetJobOfferById(int id)
        {

            var JobOffer = _jobService.GetJobOfferById(id);

            if (JobOffer!= null)
            {
                return Ok(JobOffer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddJobOffer([FromBody] Joboffer job)
        {

            if (job == null)
            {
                return BadRequest("Invalid data for JobOffer");
            }

            _jobService.AddJobOffer(job);

            return CreatedAtAction(nameof(GetJobOfferById), new { id = job.JobId }, job); 
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
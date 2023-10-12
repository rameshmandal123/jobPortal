using budhtechjobapp.Data;
using budhtechjobapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace budhtechjobapp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        public readonly IJobListingDL _jobListingDL;
        public JobListingController(IJobListingDL jobListingDL)
        {
            _jobListingDL = jobListingDL;
        }

        //post job
        [HttpPost]
        public async Task<IActionResult> JopPost(JobListingRequest jobListingRequest)
        {
            ResponseDto response = new ResponseDto();
            response.IsSuccess = true;
            response.Message = "saved jop Post";
            try
            {
                await _jobListingDL.JopPostAsynch(jobListingRequest);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        // get list of job
        [HttpGet]
        public async Task<IActionResult> GetListOfJob()
        {
            try
          {
                // Retrieve the list of job listings asynchronously
                var jobListings = await _jobListingDL.GetJobListingsAsync();

                return Ok(jobListings);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                });
            }


        }
        //search job
        [HttpGet("search")]
        public async Task<IActionResult> SearchJobListingsByTitle(string jobTitle)
        {
            try
            {
                var jobListings = await _jobListingDL.SearchJobListingsByTitleAsync(jobTitle);

                if (jobListings != null && jobListings.Any())
                {
                    return Ok(jobListings); // Return the list of matching job listings
                }
                else
                {
                    return NotFound("No job listings found with the specified JobTitle");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

    }
}

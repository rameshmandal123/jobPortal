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

                // Check if jobListings is not null or empty
                if (jobListings != null && jobListings.Count > 0)
                {
                    return Ok(new ResponseDto
                    {
                        IsSuccess = true,
                        Message = "Retrieved job listings successfully.",

                    });
                }
                else
                {
                    return NotFound(new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "No job listings found."
                    });
                }
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
    }
}

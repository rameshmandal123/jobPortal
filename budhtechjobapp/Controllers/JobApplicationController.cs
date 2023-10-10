using budhtechjobapp.Data;
using budhtechjobapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace budhtechjobapp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationDL _jobApplicationDL;

        public JobApplicationController(IJobApplicationDL jobApplicationDL)
        {
            _jobApplicationDL = jobApplicationDL ?? throw new ArgumentNullException(nameof(jobApplicationDL));
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob([FromBody] JobApplication jobApplication)
        {
            if (jobApplication == null)
            {
                return BadRequest("Invalid job application data.");
            }

            try
            {
                var response = await _jobApplicationDL.ApplyJobAsynch(jobApplication);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

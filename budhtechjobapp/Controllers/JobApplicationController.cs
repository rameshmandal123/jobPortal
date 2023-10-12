using budhtechjobapp.Data;
using budhtechjobapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Security.Principal;
using System;

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
        public async Task<IActionResult> ApplyJob(JobApplication jobApplication)
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

        [HttpGet("{jobId}")]
        public async Task<IActionResult> GetJobApplicationById(int jobId)
        {
            try
            {
                var jobApplication = await _jobApplicationDL.GetJobApplicationByIdAsync(jobId);

                if (jobApplication != null)
                {
                    return Ok(jobApplication);
                }
                else
                {
                    return NotFound("Job application not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfApplicant()
        {
            try
            {
                // Retrieve the list of job listings asynchronously
                var jobApplicant = await _jobApplicationDL.GetJobApplicationsAsync();

                return Ok(jobApplicant);

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


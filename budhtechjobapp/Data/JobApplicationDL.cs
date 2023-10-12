using budhtechjobapp.DbConfigures;
using budhtechjobapp.Models;
using Microsoft.EntityFrameworkCore;

namespace budhtechjobapp.Data
{
    public class JobApplicationDL : IJobApplicationDL
    {
        public IConfiguration _configuration;
        public MyDbContext _dbContext;
        public JobApplicationDL(
            IConfiguration configuration,
            MyDbContext myDbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }
        public async Task<ResponseDto> ApplyJobAsynch(JobApplication jobApplication)
        {
            try
            {
                if (!IsValid(jobApplication))
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Invalid input data."
                    };
                }

                var newJobApplication = new JobApplication
                {
                    ApplicantName = jobApplication.ApplicantName,
                    ApplicantEmail = jobApplication.ApplicantEmail,
                    ApplicantLocation = jobApplication.ApplicantLocation,
                    JobTitle = jobApplication.JobTitle,
                    ApplyDate = DateTime.UtcNow,

                };

                _dbContext.JobTable.Add(newJobApplication);
                await _dbContext.SaveChangesAsync();

                return new ResponseDto
                {
                    IsSuccess = true,
                    Message = "Job application submitted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<JobApplication> GetJobApplicationByIdAsync(int jobId)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var jobApplication = await _dbContext.JobTable
                    .FirstOrDefaultAsync(ja => ja.Id == jobId);

                return jobApplication;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<JobApplication>> GetJobApplicationsAsync()
        {
            try
            {
                var jobListings = await _dbContext.JobTable.ToListAsync();

                return jobListings;
            }
            catch (Exception ex)
            {
                return new List<JobApplication>();
            }
        }

        //chek valid
        private bool IsValid(JobApplication request)
        {
            return true;
        }
    }
}

using budhtechjobapp.DbConfigures;
using budhtechjobapp.Models;

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
                    //ResumeUrlFile = jobApplication.ResumeUrlFile,
                    ApplyDate = DateTime.UtcNow,
                    JobListingId = jobApplication.JobListingId,
                    SignupId = jobApplication.SignupId
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

        public Task<JobApplication> GetJobApplicationByIdAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        //chek valid
        private bool IsValid(JobApplication request)
        {
            return true;
        }
    }
}

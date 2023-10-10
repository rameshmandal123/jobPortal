using budhtechjobapp.DbConfigures;
using budhtechjobapp.Models;
using Microsoft.EntityFrameworkCore;

namespace budhtechjobapp.Data
{
    public class JobListingDL : IJobListingDL
    {
        public IConfiguration _configuration;
        public MyDbContext _dbContext;
        public JobListingDL(
            IConfiguration configuration,
            MyDbContext myDbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }
        // get all job
        public async Task<List<JobListingRequest>> GetJobListingsAsync()
        {
            try
            {
                var jobListings = await _dbContext.JobListingRequests.ToListAsync();

                return jobListings;
            }
            catch (Exception ex)
            {
                return new List<JobListingRequest>();
            }
        }

        // post job
        public async Task<ResponseDto> JopPostAsynch(JobListingRequest request)
        {
            try
            {
                // 1. Validate the input data (you can use data annotations or FluentValidation)
                if (!IsValid(request))
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        Message = "Invalid input data."
                    };
                }

                // 2. Create a new JobListingRequest entity and populate it
                var newJobListing = new JobListingRequest
                {
                    JobTitle = request.JobTitle,
                    JobDescription = request.JobDescription,
                    JobLocation = request.JobLocation,
                    CompanyName = request.CompanyName,
                    DatePosted = DateTime.UtcNow // You might want to set the posting date
                };

                _dbContext.JobListingRequests.Add(newJobListing);
                await _dbContext.SaveChangesAsync();

                return new ResponseDto
                {
                    IsSuccess = true,
                    Message = "Job listing posted successfully."
                };
            }
            catch (Exception ex)
            {
                // 4. Handle any exceptions and return an error response
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        private bool IsValid(JobListingRequest request)
        {
            return true; 
        }

    }
}

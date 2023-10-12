using budhtechjobapp.Models;

namespace budhtechjobapp.Data
{
    public interface IJobListingDL
    {
        public Task<ResponseDto> JopPostAsynch(JobListingRequest request);

        Task<List<JobListingRequest>> GetJobListingsAsync();

        Task<List<JobListingRequest>> SearchJobListingsByTitleAsync(string jobTitle);
    }
}


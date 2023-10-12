using budhtechjobapp.Models;

namespace budhtechjobapp.Data
{
    public interface IJobApplicationDL
    {
        public Task<ResponseDto> ApplyJobAsynch(JobApplication jobApplication);
        Task<JobApplication> GetJobApplicationByIdAsync(int jobId);
        Task<List<JobApplication>> GetJobApplicationsAsync();
    }
}

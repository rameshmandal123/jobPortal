using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace budhtechjobapp.Models
{
    [Table("JobListingRequests", Schema = "public")]
    public class JobListingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId {  get; set; }

        
        public string? JobTitle { get; set; }

        
        public string JobDescription { get; set; } = string.Empty;

        
        public string? JobLocation { get; set; }

        
        public string? CompanyName { get; set; }

        public DateTime DatePosted { get; set; }

       // public ICollection<JobApplication>? JobApplications { get; set; }
    }

   
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace budhtechjobapp.Models
{
    [Table("JobTable", Schema = "public")]
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? ApplicantName { get; set; }

        public string? ApplicantEmail { get; set; }

        public string? ResumeUrlFile { get; set; }

        [ForeignKey("JobListing")]
        public int JobListingId { get; set; }
        public JobListingRequest? JobListing { get; set; }

        [ForeignKey("Userid")]
        public int SignupId { get; set; }
        public SignupRequest? SignupRequest { get; set; }

        public DateTime ApplyDate { get; set; }

    }
}

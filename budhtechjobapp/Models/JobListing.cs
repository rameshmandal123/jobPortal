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

        [Required]
        public string? JobTitle { get; set; }

        [Required]
        public string JobDescription { get; set; } = string.Empty;

        [Required]
        public string? JobLocation { get; set; }

        [Required]
        public string? CompanyName { get; set; }

        public DateTime DatePosted { get; set; }
    }

   
}

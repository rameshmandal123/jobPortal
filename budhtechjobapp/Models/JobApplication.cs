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

        public string? ApplicantLocation { get; set; }
        public string? JobTitle { get; set; }

        public DateTime ApplyDate { get; set; }

    }
}

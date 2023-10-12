using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace budhtechjobapp.Models
{
    [Table("SignupRequests", Schema = "public")]
    public class SignupRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; } = null;
        
        public string? Role { get; set; }
        
    }

    public class SignupResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}

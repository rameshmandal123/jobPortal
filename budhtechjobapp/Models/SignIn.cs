using System.ComponentModel.DataAnnotations.Schema;

namespace budhtechjobapp.Models
{
    [Table("SignIn")]
    public class SignInRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; } = null;

        
    }

    public class SignInResponse
    {
        public bool? IsSuccess { get; set; }
        public string? Message { get; set;}
        public string? Role { get; set; }
    }
}

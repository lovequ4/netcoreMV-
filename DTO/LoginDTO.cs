using System.ComponentModel.DataAnnotations;

namespace examMVC.DTO
{
    public class LoginDTO
    {
        [Required]
        public string NameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace examMVC.Models
{
    [Index(nameof(Email), IsUnique = true)]  // email唯一，EntityFramework設定方法
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "user";
    }
}

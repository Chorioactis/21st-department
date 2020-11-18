using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Login { get; set; }
        public int PasswordSalt { get; set; }
        [StringLength(50)]
        public string PasswordHash { get; set; }
    }
}
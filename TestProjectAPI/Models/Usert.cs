using System.ComponentModel.DataAnnotations;

namespace TestProjectAPI.Models
{
    public class Usert
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

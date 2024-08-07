using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int surname { get; set; }

        public int? MobileNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Address { get; set; }


    }
}

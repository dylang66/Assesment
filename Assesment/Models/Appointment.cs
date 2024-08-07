using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Appointment
    {

        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }


        [Required]

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string? Comment { get; set; }
    }
}

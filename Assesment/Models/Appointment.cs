using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Appointment
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }

        public string? Comment { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Phone]
        public string? MobileNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

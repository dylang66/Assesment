using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product")]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
    }
}

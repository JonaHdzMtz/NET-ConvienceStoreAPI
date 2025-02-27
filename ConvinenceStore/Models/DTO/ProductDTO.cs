using System.ComponentModel.DataAnnotations;

namespace ConvinenceStore.Models.DTO
{
    public class ProductDTO
    {
        public long IdProduct { get; set; }
        [Required]
        [MinLength(1)]
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long? Stock { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int Stock { get; set; }
        [Required]

        public string Category { get; set; }
        public string Image { get; set; }


        public string Description { get; set; }
    }
}

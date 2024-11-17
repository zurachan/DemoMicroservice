using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

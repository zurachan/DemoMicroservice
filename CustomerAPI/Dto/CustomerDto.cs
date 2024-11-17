using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}

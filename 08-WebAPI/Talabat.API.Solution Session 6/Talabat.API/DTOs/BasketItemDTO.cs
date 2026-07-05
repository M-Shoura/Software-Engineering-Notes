using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTOs
{
    public class BasketItemDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public string PictureUrl { get; set; }

        [Required]
        [Range(0.1, double.MaxValue , ErrorMessage ="Price must be greater then Zero.")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be 1 item at least.")]
        public int Quantity { get; set; }

        [Required] 
        public string Category { get; set; }

        [Required] 
        public string Brand { get; set; }
    }
}
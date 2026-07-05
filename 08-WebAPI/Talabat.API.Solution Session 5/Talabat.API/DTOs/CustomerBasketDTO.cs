using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Talabat.Core.Entities.Basket;

namespace Talabat.API.DTOs
{
    public class CustomerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public List<BasketItemDTO> Items { get; set; }
    }
}

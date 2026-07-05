namespace Talabat.API.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }            // id of the product inside the order 
        public int ProductId { get; set; }     // id of the product from the products table 
        public string ProductName { get; set; }
        public string PictureURL { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
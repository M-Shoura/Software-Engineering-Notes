namespace Talabat.Core.Entities.Basket
{
    public class BasketItem
    {
        // Basket item : A product that is selected as an Item inside the Basket ( one time with quantity >= 1 )

        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

    }
}
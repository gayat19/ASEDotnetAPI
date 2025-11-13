namespace InventoryAPI.Models.Dtos
{
    public class ProductDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public int StockInHand { get; set; }
        public string? Image { get; set; }
    }
}

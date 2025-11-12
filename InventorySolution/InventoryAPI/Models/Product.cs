namespace InventoryAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Title { get; set; } 
        public decimal Price { get; set; }

        public int StockInHand { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? ProductImage { get; set; }

        public ICollection<InvoiceProduct>? Invoices { get; set; }
    }
}

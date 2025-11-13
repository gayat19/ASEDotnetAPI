namespace InventoryAPI.Models.Dtos
{
    public class Range
    {
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
    }
    public class ProductSearchDto
    {
        public string? Title { get; set; }
        public Range? PriceRange { get; set; }
        public bool? IsInStock { get; set; }

        // 1 - Ascending, -1 - Descending of price
        public int SortOrder { get; set; }

    }
}

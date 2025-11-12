using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class InvoiceProduct
    {

        public int Sno { get; set; }

        public int ProductId { get; set; }
        public int InvoiceNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Navigation Property

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("InvoiceNumber")]
        public Invoice? Invoice { get; set; }

    }
}

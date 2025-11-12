using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public float Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; } = "New";

        //Navigation property
        public ICollection<InvoiceProduct>? Products { get; set; }

    }
}

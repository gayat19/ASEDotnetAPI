using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public float Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; } = "New";

        public string? Username { get; set; }

        //Navigation property
        public ICollection<InvoiceProduct>? Products { get; set; }

        [ForeignKey("Username")]
        public User? User { get; set; }

    }
}

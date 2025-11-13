

using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Contexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasKey(i=>i.InvoiceNumber)
                .HasName("PK_InvoiceNumber");

            modelBuilder.Entity<InvoiceProduct>()
                .HasKey(ip => ip.Sno);

            modelBuilder.Entity<InvoiceProduct>()
                .HasOne(ip => ip.Product)
                .WithMany(p=>p.Invoices)
                .HasForeignKey(ip => ip.ProductId)
                .HasConstraintName("FK_InvoiceProduct_Product")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceProduct>()
               .HasOne(ip => ip.Invoice)
               .WithMany(i => i.Products)
               .HasForeignKey(ip => ip.InvoiceNumber)
               .HasConstraintName("FK_InvoiceProduct_Invoice")
               .OnDelete(DeleteBehavior.Restrict);


        }

    }
}

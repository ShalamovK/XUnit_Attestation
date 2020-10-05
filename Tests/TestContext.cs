using Common.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestWebApp.Tests {
    public class TestContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseInMemoryDatabase("TestDB");
        }

        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceLine> InvoiceLines { get; set; }
    } 
}

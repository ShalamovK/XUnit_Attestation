using Common.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class AppContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = XUnitTest; User Id = xunituser; Password = 123456; MultipleActiveResultSets = True");
        }

        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceLine> InvoiceLines { get; set; }
    }
}

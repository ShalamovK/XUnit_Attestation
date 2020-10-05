using Common.Contracts;
using Common.Contracts.Repos;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitTestWebApp.Tests {
    public class TestUnitOfWork : IUnitOfWork {
        private readonly TestContext _dbContext;

        private IInvoiceRepository _invoiceRepository;
        private IInvoiceLineRepository _invoiceLineRepository;

        public TestUnitOfWork() {
            _dbContext = new TestContext();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public DbContext DbContext {
            get {
                return _dbContext;
            }
        }

        public IInvoiceRepository Invoices {
            get { return _invoiceRepository ??= new InvoiceRepository(_dbContext); }
        }

        public IInvoiceLineRepository InvoiceLines {
            get { return _invoiceLineRepository ??= new InvoiceLineRepository(_dbContext); }
        }

        public void Commit() {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync() {
            _dbContext.ChangeTracker.DetectChanges();
            await _dbContext.SaveChangesAsync();
        }
        public void Rollback() {
            foreach (var entry in _dbContext.ChangeTracker.Entries()) {
                switch (entry.State) {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        public void DetachAll() {
            var entries = _dbContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in entries) {
                entry.State = EntityState.Detached;
            }
        }
    }
}

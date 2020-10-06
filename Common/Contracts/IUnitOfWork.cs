using Common.Contracts.Repos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Common.Contracts {
    public interface IUnitOfWork {
        DbContext DbContext { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceLineRepository InvoiceLines { get; }
        IPaymentRepository Payments { get; }

        void Commit();
        Task CommitAsync();
        void Rollback();
        // Removes all tracked entities from current context
        void DetachAll();
    }
}

using Common.Contracts.Repos.Base;
using Common.Models.Entities;
using System;

namespace Common.Contracts.Repos {
    public interface IInvoiceLineRepository : IBaseRepository<Guid, InvoiceLine> {
    }
}

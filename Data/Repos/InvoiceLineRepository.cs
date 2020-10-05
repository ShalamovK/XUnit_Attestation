using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos {
    public class InvoiceLineRepository : BaseRepository<Guid, InvoiceLine>, IInvoiceLineRepository {
        public InvoiceLineRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}

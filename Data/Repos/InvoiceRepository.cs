using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using System;

namespace Data.Repos {
    public class InvoiceRepository : BaseRepository<Guid, Invoice>, IInvoiceRepository {
        public InvoiceRepository(AppContext dbContext) : base(dbContext) {
        }
    }
}

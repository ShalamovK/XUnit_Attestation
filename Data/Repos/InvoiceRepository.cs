using Common.Contracts.Repos;
using Common.Models.Entities;
using Data.Repos.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Repos {
    public class InvoiceRepository : BaseRepository<Guid, Invoice>, IInvoiceRepository {
        public InvoiceRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}

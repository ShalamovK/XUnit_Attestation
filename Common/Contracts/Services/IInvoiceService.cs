using Common.Contracts.Services.Base;
using Common.Models.Dtos;
using System;
using System.Collections.Generic;

namespace Common.Contracts.Services {
    public interface IInvoiceService : IService {
        void CreateInvoice(InvoiceDto invoice, out Guid? newId);
        decimal UpdateInvoiceBalance(Guid id);
        List<InvoiceDto> GetInvoices();
    }
}

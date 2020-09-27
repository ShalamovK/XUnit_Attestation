using Common.Contracts;
using Common.Contracts.Services;
using Common.Models.Dtos;
using Common.Models.Entities;
using Logic.Services.Base;
using System;
using System.Linq;

namespace Logic.Services {
    public class InvoiceService : BaseService, IInvoiceService {
        public InvoiceService(IServiceHost serviceHost, IUnitOfWork unitOfWork) : base(serviceHost, unitOfWork) {
        }

        public void CreateInvoice(InvoiceDto invoice, out Guid? newId) {
            newId = null;

            if (invoice == null) {
                return;
            }

            Invoice newInvoice = new Invoice {
                Id = Guid.NewGuid(),
                Lines = invoice.Lines?.Select(l => new InvoiceLine {
                    Id = Guid.NewGuid(),
                    Description = l.Description,
                    Qty = l.Qty,
                    Rate = l.Rate
                }).ToList()
            };

            _unitOfWork.Invoices.Add(newInvoice);
            _unitOfWork.Commit();

            newId = newInvoice.Id;
            return;
        }
    }
}

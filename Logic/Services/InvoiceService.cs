using AutoMapper;
using Common.Contracts;
using Common.Contracts.Services;
using Common.Models.Dtos;
using Common.Models.Entities;
using Logic.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Services {
    public class InvoiceService : BaseService, IInvoiceService {
        public InvoiceService(IMapper mapper, IServiceProvider serviceHost, IUnitOfWork unitOfWork) : base(mapper, serviceHost, unitOfWork) {
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

        public List<InvoiceDto> GetInvoices() {
            List<Invoice> invoices = _unitOfWork.Invoices.GetAll()
                .Include(x => x.Lines)
                .ToList();

            return _mapper.Map<List<InvoiceDto>>(invoices);
        }

        public decimal UpdateInvoiceBalance(Guid id) {
            Invoice invoice = _GetInvoice(id);

            if (invoice == null) return 0m;

            decimal balance = invoice.UpdatePricing();
            _unitOfWork.Commit();

            return balance;
        }

        private Invoice _GetInvoice(Guid id) {
            Invoice invoice = _unitOfWork.Invoices.GetAll()
                .Include(x => x.Payments).ThenInclude(p => p.Refunds)
                .Include(x => x.Lines)
                .FirstOrDefault(x => x.Id == id);

            return invoice;
        }
    }
}

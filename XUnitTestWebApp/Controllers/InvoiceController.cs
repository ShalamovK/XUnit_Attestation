using AutoMapper;
using Common.Contracts.Services;
using Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using XUnitTestWebApp.Controllers.Base;
using XUnitTestWebApp.Models;

namespace XUnitTestWebApp.Controllers {
    public class InvoiceController : BaseController {
        public InvoiceController(IMapper mapper, IServiceProvider serviceHost) 
            : base(mapper, serviceHost) {
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Details(Guid id) {
            InvoiceDto invoiceDto = _serviceHost.GetRequiredService<IInvoiceService>().GetInvoice(id);
            InvoiceViewModel invoiceViewModel = _mapper.Map<InvoiceViewModel>(invoiceDto);

            return View(invoiceViewModel);
        }

        [HttpPost]
        public JsonResult CreateInvoice(InvoiceViewModel invoice) {
            InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            _serviceHost.GetRequiredService<IInvoiceService>().CreateInvoice(invoiceDto, out Guid? newId);

            if (newId == null) {
                return Json("error");
            } else {
                return Json(new { Result = "success", Id = newId });
            }
        }

        [HttpGet]
        public PartialViewResult GetInvoices() {
            List<InvoiceDto> invoices = _serviceHost.GetService<IInvoiceService>().GetInvoices();
            List<InvoiceViewModel> viewModels = _mapper.Map<List<InvoiceViewModel>>(invoices);

            return PartialView("Partials/_InvoicesTable", viewModels);
        }
    }
}

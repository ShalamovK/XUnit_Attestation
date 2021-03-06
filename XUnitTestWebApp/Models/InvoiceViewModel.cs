﻿using System;
using System.Collections.Generic;
using XUnitTestWebApp.Models.Base;

namespace XUnitTestWebApp.Models {
    public class InvoiceViewModel : BaseEntityViewModel<Guid> {
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
        public decimal PaidAmount { get; set; }
        public List<InvoiceLineViewModel> Lines { get; set; }

        public static InvoiceViewModel CreateDefault() {
            InvoiceViewModel invoice = new InvoiceViewModel { 
                Lines = new List<InvoiceLineViewModel>()
            };

            for (int i = 0; i < 5; i++) {
                invoice.Lines.Add(new InvoiceLineViewModel());
            }

            return invoice;
        }
    }
}

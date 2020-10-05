using Common.Contracts.Models;
using System;
using XUnitTestWebApp.Models.Base;

namespace XUnitTestWebApp.Models {
    public class InvoiceLineViewModel : BaseEntityViewModel<Guid>, IPricingEntity {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalPrice() {
            return this.TotalPrice();
        }
    }
}

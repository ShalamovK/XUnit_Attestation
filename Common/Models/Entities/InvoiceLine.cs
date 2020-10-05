using Common.Contracts.Models;
using Common.Extensions;
using Common.Models.Entities.Base;
using System;

namespace Common.Models.Entities {
    public class InvoiceLine : BaseEntity<Guid>, IPricingEntity {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalPrice() {
            return this.GetTotalPrice();
        }
    }
}

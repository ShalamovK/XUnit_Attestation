using Common.Contracts.Models;
using Common.Models.Dtos.Base;
using System;

namespace Common.Models.Dtos {
    public class InvoiceLineDto : BaseEntityDto<Guid>, IPricingEntity {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalPrice() {
            return this.TotalPrice();
        }
    }
}

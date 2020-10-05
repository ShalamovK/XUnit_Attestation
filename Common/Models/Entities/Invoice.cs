using Common.Contracts.Models;
using Common.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models.Entities {
    public class Invoice : BaseEntity<Guid> {
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
        public decimal PaidAmount { get; set; }

        // Navigation
        public virtual ICollection<InvoiceLine> Lines { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// Returns Balance
        /// </summary>
        /// <returns></returns>
        public decimal UpdatePricing() {
            this.Price = this.Lines == null ? 0m : this.Lines.Sum(l => l.TotalPrice());
            this.PaidAmount = this.Payments == null ? 0m : this.Payments.Sum(l => l.TotalPaid());

            this.Balance = this.Price - this.PaidAmount;
            return this.Balance;
        }
    }
}

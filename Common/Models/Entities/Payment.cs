using Common.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models.Entities {
    public class Payment : BaseEntity<Guid> {
        public decimal Amount { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string TransactionNum { get; set; }

        // Navigation
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<Refund> Refunds { get; set; }

        public decimal TotalPaid() {
            return this.Amount - TotalRefunded();
        }

        public decimal TotalRefunded() {
            if (this.Refunds == null) return 0m;

            return this.Refunds.Sum(r => r.Amount);
        }
    }
}

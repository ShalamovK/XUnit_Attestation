using Common.Models.Entities.Base;
using System;
using System.Collections.Generic;

namespace Common.Models.Entities {
    public class Invoice : BaseEntity<Guid> {
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
        public decimal PaidAmount { get; set; }

        // Navigation
        public virtual ICollection<InvoiceLine> Lines { get; set; }
    }
}

using Common.Models.Entities.Base;
using System;

namespace Common.Models.Entities {
    public class Refund : BaseEntity<Guid> {
        public decimal Amount { get; set; }
        public Guid PaymentId { get; set; }

        // Navigation
        public virtual Payment Payment { get; set; }
    }
}

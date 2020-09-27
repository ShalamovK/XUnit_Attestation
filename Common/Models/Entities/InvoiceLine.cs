using Common.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.Entities {
    public class InvoiceLine : BaseEntity<Guid> {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
    }
}

using Common.Models.Dtos.Base;
using System;

namespace Common.Models.Dtos {
    public class InvoiceLineDto : BaseEntityDto<Guid> {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
    }
}

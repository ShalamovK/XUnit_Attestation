using Common.Models.Dtos.Base;
using System;
using System.Collections.Generic;

namespace Common.Models.Dtos {
    public class InvoiceDto : BaseEntityDto<Guid> {
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
        public decimal PaidAmount { get; set; }
        public List<InvoiceLineDto> Lines { get; set; }
    }
}

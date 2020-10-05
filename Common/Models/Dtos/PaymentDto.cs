using Common.Models.Dtos.Base;
using System;
using System.Collections.Generic;

namespace Common.Models.Dtos {
    public class PaymentDto : BaseEntityDto<Guid> {
        public decimal Amount { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string TransactionNum { get; set; }
        public List<RefundDto> Refunds { get; set; }
    }
}

using Common.Models.Dtos.Base;
using System;

namespace Common.Models.Dtos {
    public class RefundDto : BaseEntityDto<Guid> {
        public decimal Amount { get; set; }
        public Guid PaymentId { get; set; }
    }
}

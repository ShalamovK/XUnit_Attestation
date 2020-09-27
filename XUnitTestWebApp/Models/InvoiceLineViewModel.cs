using System;
using XUnitTestWebApp.Models.Base;

namespace XUnitTestWebApp.Models {
    public class InvoiceLineViewModel : BaseEntityViewModel<Guid> {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
    }
}

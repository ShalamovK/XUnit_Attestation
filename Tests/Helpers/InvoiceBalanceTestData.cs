using System.Collections;
using System.Collections.Generic;

namespace XUnitTestWebApp.Tests.Helpers {
    public class InvoiceBalanceTestData : IEnumerable<object[]> {
        public IEnumerator<object[]> GetEnumerator() {
            yield return new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Unpaid(), 1 };
            yield return new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Unpaid1(), 1 };
            yield return new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Paid(), 0 };
            yield return new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Paid_Refunded(), 1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

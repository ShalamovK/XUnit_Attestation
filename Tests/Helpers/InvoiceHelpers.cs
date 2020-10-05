using Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestWebApp.Tests.Helpers {
    public static class InvoiceHelpers {
        public static object[] GetLinesHelper() {
            return new List<InvoiceLine> {
                new InvoiceLine {
                    Id = Guid.NewGuid(),
                    Description = "TEST LINE 1",
                    Qty = 12,
                    Rate = 5.50m
                },
                new InvoiceLine {
                    Id = Guid.NewGuid(),
                    Description = "TEST LINE 2",
                    Qty = 6,
                    Rate = 12.00m
                }
            }.ToArray();
        }

        public static object[] GetPaymentsHelper_Unpaid() {
            return new List<Payment> {
                new Payment {
                    Id = Guid.NewGuid(),
                    Amount = 100,
                    Date = DateTime.Now,
                    TransactionNum = "12345"
                }
            }.ToArray();
        }

        public static object[] GetPaymentsHelper_Unpaid1() {
            return new List<Payment> {
                new Payment {
                    Id = Guid.NewGuid(),
                    Amount = 100,
                    Date = DateTime.Now,
                    TransactionNum = "12345"
                },
                new Payment {
                    Id = Guid.NewGuid(),
                    Amount = 12,
                    Date = DateTime.Now,
                    TransactionNum = "12346"
                }
            }.ToArray();
        }

        public static object[] GetPaymentsHelper_Paid() {
            return new List<Payment> {
                new Payment {
                    Id = Guid.NewGuid(),
                    Amount = 138m,
                    Date = DateTime.Now,
                    TransactionNum = "12347"
                }
            }.ToArray();
        }

        public static object[] GetPaymentsHelper_Paid_Refunded() {
            return new List<Payment> {
                new Payment {
                    Id = Guid.NewGuid(),
                    Amount = 138m,
                    Date = DateTime.Now,
                    TransactionNum = "12348",
                    Refunds = new List<Refund> {
                        new Refund {
                            Id = Guid.NewGuid(),
                            Amount = 38m
                        }
                    }
                }
            }.ToArray();
        }
    }
}

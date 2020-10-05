using Common.Contracts.Models;
using Common.Extensions;
using Common.Models.Entities;
using Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;
using XUnitTestWebApp.Tests.Helpers;

namespace XUnitTestWebApp.Tests.UnitTests {
    public class InvoiceTests {
        [Fact]
        public void Balance_Should_Be_Zero() {
            Invoice invoice = new Invoice {
                Lines = new List<InvoiceLine> {
                    new InvoiceLine {
                        Qty = 5,
                        Rate = 12
                    }
                },
                Payments = new List<Payment> {
                    new Payment { 
                        Amount = 70,
                        Refunds = new List<Refund> {
                            new Refund {
                                Amount = 10
                            }
                        }
                    }
                }
            };

            decimal balance = invoice.UpdatePricing();

            Assert.Equal(0m, balance);
        }

        [Theory]
        [InlineData(60, 0)]
        [InlineData(50, 10)]
        [InlineData(10.5, 49.5)]
        public void Test_Balance(decimal paymentAmount, decimal expectedAmount) {
            Invoice invoice = _GetTestInvoice_60();

            invoice.Payments = new List<Payment> {
                new Payment {
                    Amount = paymentAmount
                }
            };

            Assert.Equal(expectedAmount, invoice.UpdatePricing());
        }

        [Theory]
        [MemberData(nameof(GetTestBalanceData))]
        public void Test_Balance1(InvoiceLine[] lines, Payment[] payments, int balanceSignExpected) {
            var invoice = new Invoice {
                Lines = lines,
                Payments = payments
            };

            invoice.UpdatePricing();

            int sign = Math.Sign(invoice.Balance);
            Assert.Equal(balanceSignExpected, sign);
        }

        [Theory]
        [ClassData(typeof(InvoiceBalanceTestData))]
        public void Test_Balance2(InvoiceLine[] lines, Payment[] payments, int balanceSignExpected) {
            var invoice = new Invoice {
                Lines = lines,
                Payments = payments
            };

            invoice.UpdatePricing();

            int sign = Math.Sign(invoice.Balance);
            Assert.Equal(balanceSignExpected, sign);
        }

        [Fact]
        public void Test_Invoice_Saving() {
            Invoice invoice = new Invoice {
                Id = Guid.NewGuid(),
                Lines = new List<InvoiceLine> {
                    new InvoiceLine {
                        Id = Guid.NewGuid(),
                        Description = "Test Line",
                        Qty = 5,
                        Rate = 12
                    }
                },
            };

            var unitOfWork = new TestUnitOfWork();

            unitOfWork.Invoices.Add(invoice);
            unitOfWork.Commit();

            Invoice result = unitOfWork.Invoices.GetById(invoice.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Invoice_Saving1() {
            Guid lineId = Guid.NewGuid();

            Invoice invoice = new Invoice {
                Id = Guid.NewGuid(),
                Lines = new List<InvoiceLine> {
                    new InvoiceLine {
                        Id = lineId,
                        Description = "Test Line XUnit",
                        Qty = 5,
                        Rate = 12
                    }
                },
            };

            var unitOfWork = new UnitOfWork();

            unitOfWork.Invoices.Add(invoice);
            unitOfWork.Commit();

            InvoiceLine result = unitOfWork.InvoiceLines.GetById(lineId);

            Assert.NotNull(result);
        }

        #region [ HELPERS ]

        public static IEnumerable<object[]> GetTestBalanceData {
            get {
                return new List<object[]> {
                    new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Unpaid(), 1 },
                    new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Unpaid1(), 1 },
                    new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Paid(), 0 },
                    new object[] { InvoiceHelpers.GetLinesHelper(), InvoiceHelpers.GetPaymentsHelper_Paid_Refunded(), 1 }
                };
            }
        }

        private Invoice _GetTestInvoice_60() {
            Invoice invoice = new Invoice {
                Lines = new List<InvoiceLine> {
                    new InvoiceLine {
                        Qty = 5,
                        Rate = 12
                    }
                },
            };

            return invoice;
        }

        #endregion
    }
}

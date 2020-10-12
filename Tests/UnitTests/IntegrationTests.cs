using AutoMapper;
using Common.Contracts;
using Common.Contracts.Repos;
using Common.Contracts.Services;
using Common.Models.Dtos;
using Common.Models.Entities;
using Data;
using Logic.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using XUnitTestWebApp.Models;
using XUnitTestWebApp.Tests.Helpers;

namespace XUnitTestWebApp.Tests.UnitTests {
    public class IntegrationTests {
        private TestServer _testServer;

        private void _SetupClient() {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
            
            Client = _testServer.CreateClient();
        }

        public IntegrationTests() {
            _SetupClient();
        }

        public HttpClient Client { get; private set; }

        [Fact]
        public void Test_Invoice_Index() {
            var task = Client.GetAsync("http://xunittestapp/Invoice");
            task.Wait();

            HttpResponseMessage result = task.Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void Test_Get_Invoices() {
            var task = Client.GetAsync("http://xunittestapp/Invoice/GetInvoices");
            task.Wait();

            HttpResponseMessage result = task.Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
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

        [Fact]
        public void Test_Invoice_Paid() {
            Guid invoiceId = Guid.NewGuid();

            var unitOfWork = new TestUnitOfWork();
            var mapperMock = new Mock<IMapper>();
            var serviceProviderMock = new Mock<IServiceProvider>();
            var paymentServiceMock = new Mock<PaymentService>(mapperMock.Object, serviceProviderMock.Object, unitOfWork);
            var invoiceServiceMock = new Mock<InvoiceService>(mapperMock.Object, serviceProviderMock.Object, unitOfWork);

            serviceProviderMock.Setup(p => p.GetService(typeof(IInvoiceService)))
                .Returns(invoiceServiceMock.Object);

            Invoice invoice = new Invoice {
                Id = invoiceId,
                Lines = new List<InvoiceLine> {
                    new InvoiceLine {
                        Qty = 4,
                        Rate = 25m
                    }
                }
            };

            unitOfWork.Invoices.Add(invoice);
            unitOfWork.Commit();

            PaymentDto paymentDto = new PaymentDto {
                InvoiceId = invoiceId,
                Amount = 100m,
            };

            paymentServiceMock.Object.ProcessNewPayment(paymentDto);

            Invoice updatedInvoice = unitOfWork.Invoices.GetById(invoiceId);
            Assert.Equal(0m, updatedInvoice.Balance);
        }

        [Fact]
        public void Test_Balance_Update_Called_After_Payment() {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var paymentRepoMock = new Mock<IPaymentRepository>();
            var serviceProviderMock = new Mock<IServiceProvider>();
            var invoiceServiceMock = new Mock<IInvoiceService>();
            var paymentServiceMock = new Mock<PaymentService>(mapperMock.Object, serviceProviderMock.Object, unitOfWorkMock.Object);

            unitOfWorkMock.Setup(x => x.Payments).Returns(paymentRepoMock.Object);
            serviceProviderMock.Setup(p => p.GetService(typeof(IInvoiceService)))
                .Returns(invoiceServiceMock.Object);

            PaymentDto paymentDto = new PaymentDto {
                Amount = 100m,
                InvoiceId = Guid.Empty
            };

            paymentServiceMock.Object.ProcessNewPayment(paymentDto);

            invoiceServiceMock.Verify(s => s.UpdateInvoiceBalance(It.IsAny<Guid>()));
        }

        [Fact]
        public void Test_Delay() {
            Thread.Sleep(11000);

            Assert.True(true);
        }

        [Fact]
        public void Invoice_Details_Page_IsOk() {
            var invoiceServiceMock = new Mock<IInvoiceService>();
            invoiceServiceMock.Setup(x => x.GetInvoice(It.IsAny<Guid>())).Returns(new InvoiceDto {
                Id = Guid.NewGuid(),
                Lines = new List<InvoiceLineDto> {
                    new InvoiceLineDto {
                        Id = Guid.NewGuid(),
                        Qty = 1,
                        Rate = 100,
                        Description = "TEST CHARGE"
                    }
                },
            });

            var webHostBuilder = new WebHostBuilder()
                .ConfigureTestServices(services => {
                    services.RemoveAll<IInvoiceService>();//Remove previous registration(s) of this service
                    services.TryAddTransient<IInvoiceService>(sp => invoiceServiceMock.Object);
                })
                .UseStartup<Startup>();

            _testServer = new TestServer(webHostBuilder);
            Client = _testServer.CreateClient();

            string url = String.Format("http://xunittestapp/Invoice/Details/{0}", Guid.NewGuid().ToString());
            var task = Client.GetAsync(url);
            task.Wait();

            HttpResponseMessage result = task.Result;

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Invoice_Add_And_Get_IsOk() {
            string addUrl = "http://xunittestapp/Invoice/CreateInvoice";

            InvoiceViewModel model = new InvoiceViewModel {
                Lines = new List<InvoiceLineViewModel> {
                    new InvoiceLineViewModel {
                        Id = Guid.NewGuid(),
                        Qty = 1,
                        Rate = 100,
                        Description = "TEST CHARGE"
                    }
                },
            };

            string json = JsonConvert.SerializeObject(model);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Task<HttpResponseMessage> addTask = Client.PostAsync(addUrl, byteContent);
            addTask.Wait();

            HttpResponseMessage addTaskResult = addTask.Result;
            var contentTask = addTaskResult.Content.ReadAsStringAsync();
            contentTask.Wait();

            string data = contentTask.Result;
            dynamic responseModel = JsonConvert.DeserializeObject(data);
            Guid id = responseModel.id;

            string getUrl = String.Format("http://xunittestapp/Invoice/Details/{0}", id.ToString());

            Task<HttpResponseMessage> getTask = Client.GetAsync(getUrl);
            getTask.Wait();

            HttpResponseMessage getTaskResult = getTask.Result;

            Assert.Equal(HttpStatusCode.OK, addTaskResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, getTaskResult.StatusCode);
        }
    }
}

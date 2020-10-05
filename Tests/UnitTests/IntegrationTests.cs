using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace XUnitTestWebApp.Tests.UnitTests {
    public class IntegrationTests {
        private TestServer _testServer;

        private void _SetupClient() {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

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
    }
}

using Microsoft.AspNetCore.Mvc;
using XUnitTestWebApp.Models;

namespace XUnitTestWebApp.Controllers {
    public class InvoiceController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public JsonResult CreateInvoice(InvoiceViewModel invoice) {

        }
    }
}

#pragma checksum "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5f623cd6a4ddb5b28bdbcf30f665e90ad5e6e68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Partials__InvoicesTable), @"mvc.1.0.view", @"/Views/Invoice/Partials/_InvoicesTable.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\_ViewImports.cshtml"
using XUnitTestWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
using XUnitTestWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5f623cd6a4ddb5b28bdbcf30f665e90ad5e6e68", @"/Views/Invoice/Partials/_InvoicesTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90bdf288ad5a3397ff611919d36b64d6812992b0", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_Partials__InvoicesTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InvoiceViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>Id</tr>\r\n        <tr>Price</tr>\r\n        <tr>Balance</tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
         foreach (var invoice in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 14 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
               Write(invoice.Id.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 15 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
               Write(invoice.Price.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 16 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
               Write(invoice.Balance.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 18 "C:\Users\Kirill\source\repos\XUnitTestApp\XUnitTestWebApp\Views\Invoice\Partials\_InvoicesTable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InvoiceViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
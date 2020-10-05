// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function InitInvoices() {
    $.ajax({
        type: "GET",
        url: urls.GetInvoices,
        success: function(html) {
            $("#invoicesTable").html(html);
        },
        error: function() {
            alert("Ajax error");
        }
    });
}
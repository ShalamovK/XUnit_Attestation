function GetRemoteContent(elementId, url, data) {
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        success: function (data) {
            var element = $("#" + elementId);
            element.html(data);
        },
        error: function () {
            alert("ajax error");
        }
    });
}
//# sourceMappingURL=ajaxLoader.js.map
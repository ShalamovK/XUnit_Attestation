function GetRemoteContent(elementId: string, url: string, data: object) {
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        success: function(data) {
            const element = $("#" + elementId);
            element.html(data);
        },
        error: function() {
            alert("ajax error");
        }
    })
}
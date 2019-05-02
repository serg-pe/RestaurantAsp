function send_ajax(method, url, json_object, success_callback, error_callback) {
    
    $.ajax({
        type: method,
        url: url,
        contentType: "application/json; charset=utf-8",
        beforeSend: function(xhr) {
            xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: "json",
        data: json_object,
        success: success_callback,
        error: error_callback
    });
    
}
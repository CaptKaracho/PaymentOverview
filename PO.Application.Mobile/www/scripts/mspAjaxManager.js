
var ajaxManager = (function (domain,controller) {
    var ajaxMeta = {
        domain: domain,
        controler: controller
    }

    function executeAjax(uriParams, onReady, onError) {
        $.ajax({
            url: domain + "/api/" + ajaxMeta.controler + "/" + uriParams,
            crossDomain:true,
            beforeSend: function (xhr) {
                
                xhr.overrideMimeType("text/plain;");
            }
        })
            .done(function (data) {
                onReady(data);
                
            })
            .error(function (data) {
                onError();
            });
    }
    return { execute: executeAjax }
})
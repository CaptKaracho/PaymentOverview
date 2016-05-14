var AjaxData = (function (global, $) {
    var url, controller, method, parameter, httpMethod;

    var ajaxUrl;

    function getAjaxUrl() {
        ajaxUrl = url + "/" + controller + "/" + method + "" + castParamterJsonToAttributeString();;

    }

    function castParamterJsonToAttributeString() {
        var parString = "";
        for (var key in parameter) {
            if (parString === "")
                parString += "?";
            else
                parString += "&";

            parString += key + "=" + parameter[key];
        }
        return parString;
    }

    function ExecuteCall(onDone, onError) {

        getAjaxUrl();
        $.ajax({
            url: ajaxUrl,
            method: httpMethod,
            xhrFields: {
                withCredentials: false
            }
        }).done(function (e) {
            if (onDone != undefined)
                onDone(e);
        }).error(function (e) {
            if (onError != undefined)
                onError(e);
        });

    }

    //global.test = test;
    return {
        get_Url: url,
        set_Url: function (newUrl) { url = newUrl; },
        get_Controller: controller,
        set_Controller: function (newController) { controller = newController; },
        get_Method: method,
        set_Method: function (newMethod) { method = newMethod; },
        get_Parameter: parameter,
        set_Parameter: function (newParameter) { parameter = newParameter; },
        get_HttpMethod: httpMethod,
        set_HttpMethod: function (newHttpMethod) { httpMethod = newHttpMethod; },
        ExecuteCall: ExecuteCall
    }
})(window, $);
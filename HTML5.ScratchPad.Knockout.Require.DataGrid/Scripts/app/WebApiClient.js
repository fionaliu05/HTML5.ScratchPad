/*
N.B Gotchas

If your AJAX request contains the following setting:
dataType: "json"

The documentation states that jQuery:

Evaluates the response as JSON and returns a JavaScript object. (...) The JSON data is parsed in a strict manner; any malformed JSON is rejected and a parse error is thrown.
This means that if server returns invalid JSON with a 200 OK status then jQuery fires the error function and set the textStatus parameter to "parsererror".

Solution: make sure that the server returns valid JSON. It is worth noting that an empty response is also considered invalid JSON; you could return {} or null for example which validate as JSON.

The solution in the WebAPI response especially for DELETEs is to return a status code of HttpStatusCode.NoContent
*/

define(['jquery'], function ($) {
    
    function WebApiClient() {
        var self = this;

        //#region private variables

        self.baseUri = "http://localhost:1625";
        self.authToken = "SessionToken";

        //#endregion

        //#region private functions

        configureRequest = function (xhr) {
                xhr.setRequestHeader("Authorization", "Session " + authToken);
            };

        createUri = function(path) {
            return self.baseUri + "/" + path;
        };

        self.errorHandler = function (error) {
            alert("An error occurred: " + error.status + "," + error.responseText);
        };

        //Web api calls

        self.get_All = function (controller) {
            return $.ajax({
                url: createUri(controller),
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
                //beforeSend: configureRequest
            });
        };

        self.get_ById = function (controller, id) {
            return $.ajax({
                url: createUri(controller + id),
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
                //beforeSend: configureRequest
            });
        };

        self.post = function (controller, data) {
            return $.ajax({
                url: createUri(controller),
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: ko.toJSON(data),
            });
        };

        self.put = function (controller, data) {
            return $.ajax({
                url: createUri(controller),
                type: "PUT",
                //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: ko.toJSON(data),
            });
        };

        self.delete = function (controller, data, id) {
            return $.ajax({
                cache: false,
                type: 'DELETE',
                url: createUri(controller + id),
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: ko.toJSON(data),
                crossDomain: true
            });
        };

        //#endregion
    }

    return (WebApiClient);
});
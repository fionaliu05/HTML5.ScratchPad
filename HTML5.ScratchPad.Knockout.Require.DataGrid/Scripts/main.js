//Define module loading for jQuery, knockout and view Model including config

/*
RequireJS requires we have to tell it where files are so we can use those aliases
RequireJS uses the baseUrl setting in main.js if you pass it a script name that is not an alias in the paths section.  
In other words, if you call “jquery” in your define/require, it knows from your paths setting where to go, i.e. in this case,
it looks for it in the baseUrl path, which is “/Scripts/app”.

#N.B. 
RequireJS doesnt need the JS Extension as it knows it's loading JS files.
(It’s a JavaScript loader; it knows those are JavaScript files). 

*/
require.config({
    baseUrl: "/Scripts/app",
    urlArgs: version === "" ? "" : "v=" + version, // Global assembly version, set in _Layout.cshtml
    paths: {
        knockout: "../lib/knockout-3.4.0",
        //knockoutMapping: "../lib/knockout.mapping-latest",
        jquery: "../lib/jquery-2.1.4.min",
        jqueryValidate: "../lib/jquery.validate",
        jqueryValidateUnobtrusive: "../lib/jquery.validate.unobtrusive",
        bootstrap: "../lib/bootstrap",
        modernizer: "../lib/modernizr-2.6.2",
        domReady: "../lib/domReady",
        customerViewModel: "CustomerViewModel",
        webApiClient: "WebApiClient"
    },
    //Remember: only use shim config for non-AMD scripts,
    //scripts that do not already call define(). The shim
    //config will not work correctly if used on AMD scripts,
    //in particular, the exports and init config will not
    //be triggered, and the deps config will be confusing
    //for those cases.
    shim: {
        jqueryValidate: ["jquery"],
        jqueryValidateUnobtrusive: ["jquery", "jqueryValidate"],
        underscore: {
            exports: "_"
        },
        'knockout.mapping': ['knockout']
        }
});

/*
This is a stratup file for RequireJS and Knockout view models, and adaption of Joe Wilsons Blog (Volare), May 2014
"Adding RequireJS to an ASP.NET MVC Project"

It uses a combination of MVC Helpers to inject Scripts and Content into web pages using RequireJS, DomReady and other Modules

src: http://volaresystems.com/blog/post/2014/05/27/Adding-RequireJS-to-an-ASPNET-MVC-project
*/

//This initialises common code to run on all pages 
require(['AppStartup'], function (AppStartup) {

    AppStartup.init();

    //could set up webApiClient here (DI) - actually doesnt work tried
    //var apiClient = new WebApiClient;

    require(['domReady', 'jquery', 'knockout', 'WebApiClient', 'CustomerViewModel'], function (domReady, jquery, knockout, webApiClient, customerViewModel) {

        //$(document).ready(function () {   //Swap out for domReady module

        domReady(function () {
            //Instantiate page view model
            ko.applyBindings(customerViewModel);

        });
    });

});




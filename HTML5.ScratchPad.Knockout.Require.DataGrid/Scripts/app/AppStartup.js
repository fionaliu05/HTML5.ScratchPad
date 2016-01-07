define(['jquery', 'knockout'], function ($, ko) { "use strict";

    var AppStartup = function () { };

    AppStartup.prototype.init = function () {
        // Common app code run on every page can go here

        $(document).on({
            ajaxStart: function () { $("body").addClass("loading"); },
            ajaxStop: function () { $("body").removeClass("loading"); }
        });

    };
    return new AppStartup;
});
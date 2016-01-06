/* 
Directives are custom widgets (components that are re-usable)
Used to enrich existing HTML Elements /create custom HTML tags

sideBar.directive.js 
@example <div side-Bar></div>
*/

(function (app) {
    'use strict';

    //[Style Y073]
    app.directive('sideBar', sideBar);

    /* implementation details */
    function sideBar() {
        /*
          Restrictions
          [Style Y074] restrict to elements and attributes
          General guideline is allow EA but lean towards implementing as an element when it's stand-alone and as an 
          attribute when it enhances its existing DOM element.
          */
        var directive = {
            restrict: 'E', //restrict E (custom element), and optionally restrict A (custom attribute)
            replace: true,
            templateUrl: '/app/layout/sideBar.html'
        };
        return directive
    }

})(angular.module('common.ui'));


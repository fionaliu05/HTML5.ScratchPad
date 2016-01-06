﻿///<reference path="../Scripts/typings/jquery/jquery.d.ts"/>
///<reference path="../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
///<reference path="../Scripts/typings/angularjs/angular.d.ts"/>
///<reference path="../Scripts/typings/angularjs/angular-route.d.ts" />


/*
Typescript module to define the main app module
*/

module app {
    'use strict';
    /*
    Typescript class to define the routing module, encaspulating angular routing
    
    To accomplish routing we inject the $routingProvider of type definiton file: ng.route.IRouteProvider 
    in the class constructor

    */

    class Config {
        constructor($routeProvider: ng.route.IRouteProvider,
            $modalProvider: ng.ui.bootstrap.IModalProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: "/app/templates/customers/customersView.html",
                    controller: "CustomersCtrl as vm"
                })
                //.when("/edit/:id", {
                //templateUrl: "/app/templates/customers/editCustomerView.html",
                //    controller: "CustomerEditCtrl as vm"
                //})
                .when("/about", {
                templateUrl: "/app/templates/about.html"
                    //controller: "CustomerAddCtrl as vm"
                })
                .otherwise({ redirectTo: '/' })


            ;
        }

    }

    //var modules = ['ngRoute', '$routeProvider', 'ngAnimate', 'ui.bootstrap'];
    //var mainApp = angular.module('sampleAngularApp', ['ngRoute']);

    var mainApp = angular.module('sampleAngularApp', ['ngRoute', 'ngAnimate', 'ui.bootstrap', 'ui.bootstrap.tpls']);
    mainApp.config(Config);


    Config.$inject = ['$routeProvider'];

}
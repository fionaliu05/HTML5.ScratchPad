/*
https://github.com/johnpapa/angular-styleguide

Dont use anonymous functions as a callback use named functions   

*/
(function (app) {
    'use strict';

    app.controller('customerController', CustomerController);

    /*
    Dont pass in $scope in as an argument. 
    Dont use $scope methods into a controller when it may otherwise be better to avoid them, or move the method to a factory
    and then reference them from the controller
    Consider only using $scope within a controller when needed, e.g. when publishing/subscribing to events using $emit, $broadcast, or $on
    */
    /* avoid */
    //function CustomerController($scope) {
    //  $Scope.name = {};

    function CustomerController($scope) {

         /*
         Place bindable members at the top as it makes it easier to read,  alphabetized, and not spread through the controller code.
     
         Why?: Placing bindable members at the top makes it easy to read and helps you instantly identify which members of the 
         controller can be bound and used in the View.

         Why?: Setting anonymous functions in-line can be easy, but when those functions are more than 1 line of code they can 
         reduce the readability. Defining the functions below the bindable members (the functions will be hoisted) moves 
         the implementation details down, keeps the bindable members up top, and makes it easier to read.
         */

        /* jshint validthis: true */
        var customerVm = this;

        //#region Bindable view members

        customerVm.pageClass = 'page-customers';
        customerVm.loadingCustomers = true;
        customerVm.page = 0;
        customerVm.pagesCount = 0;
        customerVm.Customers = [];

        customerVm.search = search;
        customerVm.clearSearch = clearSearch;
        customerVm.filterCustomers = '';

        customerVm.openEditDialog = openEditDialog;
      
        //#end region
     
        //#region Bindable functions

        function search(page) {
            page = page || 0;

            customerVm.loadingCustomers = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 4,
                    filter: customerVm.filterCustomers
                }
            };

            apiService.get('/api/customers/search/', config,
            customersLoadCompleted,
            customersLoadFailed);
        }

        function openEditDialog(customer) {
            customerVm.EditedCustomer = customer;
            $modal.open({
                templateUrl: 'app/customers/editCustomerModal.html',
                controller: 'customerEditController',
                scope: customerVm
            }).result.then(function (customerVm) {
                clearSearch();
            }, function () {
            });
        }

        function customersLoadCompleted(result) {
            customerVm.Customers = result.data.Items;

            customerVm.page = result.data.Page;
            customerVm.pagesCount = result.data.TotalPages;
            customerVm.totalCount = result.data.TotalCount;
            customerVm.loadingCustomers = false;

            if (customerVm.filterCustomers && customerVm.filterCustomers.length) {
                notificationService.displayInfo(result.data.Items.length + ' customers found');
            }

        }

        function customersLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            customerVm.filterCustomers = '';
            search();
        }

        //#end region

        customerVm.search();

        //Example of a watch in a Controller
        //$scope.$watch('vm.title', function (current, original) {
        //    $log.info('vm.title was %s', original);
        //    $log.info('vm.title is now %s', current);
        //});
    }

})(angular.module('home-app.mod.main'));

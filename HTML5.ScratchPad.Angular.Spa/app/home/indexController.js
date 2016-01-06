(function (app) {
    'use strict';

    app.controller('indexController', IndexController);

    IndexController.$inject = ['$scope', 'apiService', 'notificationService'];

    function IndexController($scope, apiService, notificationService) {

        var indexVm = this;

        indexVm.pageClass = 'page-home';
        indexVm.loadingCustomers = true;
        indexVm.isReadOnly = true;

        indexVm.Customers = [];
        indexVm.loadCustomerData = loadCustomerData;

        function loadCustomerData() {
            apiService.get('/api/customers/all', null,
                        customersLoadCompleted,
                        customersLoadFailed);
        }

        function customersLoadCompleted(result) {
            indexVm.Customers = result.data;
            indexVm.loadingCustomers = false;
        }

        function customersLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadCustomerData();
    }

})(angular.module('home-app.mod.main'));
(function (app) {
    'use strict';

    app.controller('rootCtrl', RootController);

    RootController.$inject = ['$scope', '$location', 'membershipService', '$rootScope'];

    function RootController($scope, $location, membershipService, $rootScope) {

        /* jshint validthis: true */
        var rootVm = this;

        rootVm.userData = {};
        
        rootVm.userData.displayUserInfo = displayUserInfo;
        rootVm.logout = logout;

        function displayUserInfo() {
            rootVm.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

            if (rootVm.userData.isUserLoggedIn)
            {
                rootVm.username = $rootScope.repository.loggedUser.username;
            }
        }

        function logout() {
            membershipService.removeCredentials();
            $location.path('#/');
            rootVm.userData.displayUserInfo();
        }

        rootVm.userData.displayUserInfo();
    }

})(angular.module('home-app.mod.main'));
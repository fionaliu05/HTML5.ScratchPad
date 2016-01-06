(function () {
	'use strict';

	//Using a setter - set once
	angular.module('home-app.mod.main', ['common.mod.core', 'common.mod.ui'])
        .config(config)
        .run(run);

    /*
    APP Routing:
    ------------
    Configure routes using the AngularJS RouteProvider service

    -We are adding client-side routing - very important part of spa apps
    -allows interception of route changes, and renders partial views (document fragments) which replace shell elements
    -the view is injected using the ng-view directive decorating the element

    */
	config.$inject = ['$routeProvider'];
	function config($routeProvider) {
		$routeProvider
            .when("/", {
            	templateUrl: "app/home/index.html",
            	controller: "indexController"
            })
            .when("/login", {
            	templateUrl: "app/account/login.html",
            	controller: "loginController"
            })
            .when("/register", {
            	templateUrl: "app/account/register.html",
            	controller: "registerController"
            })
            .when("/customers", {
            	templateUrl: "app/customers/customers.html",
            	controller: "customersController"
            })
            .when("/customers/register", {
            	templateUrl: "app/customers/register.html",
            	controller: "customersRegController",
            	resolve: { isAuthenticated: isAuthenticated }
            })
	}

	/*
	explicit service injection using the angularJS property annotation $inject which allows the minifiers to rename the 
	function parameters and still be able to inject the right services
	*/
	run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

	function run($rootScope, $location, $cookieStore, $http) {
		// handle page refreshes
		$rootScope.repository = $cookieStore.get('repository') || {};
		if ($rootScope.repository.loggedUser) {
			$http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
		}

		//can swap out with domReady.js
		$(document).ready(function () {
			$(".fancybox").fancybox({
				openEffect: 'none',
				closeEffect: 'none'
			});

			$('.fancybox-media').fancybox({
				openEffect: 'none',
				closeEffect: 'none',
				helpers: {
					media: {}
				}
			});

			$('[data-toggle=offcanvas]').click(function () {
				$('.row-offcanvas').toggleClass('active');
			});
		});
	}

	isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

	function isAuthenticated(membershipService, $rootScope, $location) {
		if (!membershipService.isUserLoggedIn()) {
			$rootScope.previousState = $location.path();
			$location.path('/login');
		}
	}

})();
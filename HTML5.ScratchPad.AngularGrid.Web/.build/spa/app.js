var app;!function(t){"use strict";var e=function(){function t(t,e){t.when("/",{templateUrl:"/app/templates/customers/customersView.html",controller:"CustomersCtrl as vm"}).when("/about",{templateUrl:"/app/templates/about.html"}).otherwise({redirectTo:"/"})}return t}(),r=angular.module("sampleAngularApp",["ngRoute","ngAnimate","ui.bootstrap","ui.bootstrap.tpls"]);r.config(e),e.$inject=["$routeProvider"]}(app||(app={}));var app;!function(t){var e;!function(e){var r;!function(e){var r=function(){function t(){this.appTitle="Sample Spa App: Customer Interactions With Promises",this.baseUri="http://localhost:1625",this.postUri="/api/Customer/"}return t}();e.ConstantsService=r,angular.module("sampleAngularApp").service("constantsService",t.common.services.ConstantsService)}(r=e.services||(e.services={}))}(e=t.common||(t.common={}))}(app||(app={}));var app;!function(t){var e;!function(e){var r;!function(e){var r=function(){function t(t,e){this.httpService=t,this.qService=e}return t.prototype.get=function(t,e){function r(){var e=o.qService.defer();return o.httpService.get(t).then(function(t){JSON.stringify(t.data),e.resolve(t.data)},function(t){e.reject(t)}),e.promise}var o=this;return r()},t.prototype.getSingle=function(t){var e=this,r=e.qService.defer();return e.httpService.get(t).then(function(t){r.resolve(t.data)},function(t){r.reject(t)}),r.promise},t.prototype.add=function(t,e){var r=this,o=r.qService.defer();return r.httpService.post(t,e).then(function(t){o.resolve(t.data)},function(t){o.reject(t)}),o.promise},t.prototype.update=function(t,e){var r=this,o=r.qService.defer();return r.httpService.put(t,e).then(function(t){o.resolve(t)},function(t){o.reject(t)}),o.promise},t.prototype.remove=function(t){var e=this,r=e.qService.defer();return e.httpService["delete"](t).then(function(t){r.resolve(t)},function(t){r.reject(t)}),r.promise},t.$inject=["$http","$q"],t}();e.DataService=r,angular.module("sampleAngularApp").service("dataService",t.common.services.DataService)}(r=e.services||(e.services={}))}(e=t.common||(t.common={}))}(app||(app={}));var __extends=this&&this.__extends||function(t,e){function r(){this.constructor=t}for(var o in e)e.hasOwnProperty(o)&&(t[o]=e[o]);r.prototype=e.prototype,t.prototype=new r},app;!function(t){var e;!function(e){var r=function(t){function e(e,r,o,s,n,i,a){t.call(this),this.AddressLine1=e,this.AddressLine2=r,this.AddressLine3=o,this.AddressLine4=s,this.Email=n,this.Postcode=i,this.AddressId=a,this.AddressId=a,this.AddressLine1=e,this.AddressLine2=r,this.AddressLine3=o,this.AddressLine4=s,this.Email=n,this.Postcode=i}return __extends(e,t),e}(t.domain.EntityBase);e.Address=r}(e=t.domain||(t.domain={}))}(app||(app={}));var __extends=this&&this.__extends||function(t,e){function r(){this.constructor=t}for(var o in e)e.hasOwnProperty(o)&&(t[o]=e[o]);r.prototype=e.prototype,t.prototype=new r},app;!function(t){var e;!function(e){var r=function(t){function e(e,r,o,s,n){t.call(this),this.FirstName=e,this.Surname=r,this.Active=o,this.Address=s,this.CustomerId=n,this.CustomerId=n,this.FirstName=e,this.Surname=r,this.Active=o,this.Address=s}return __extends(e,t),e}(t.domain.EntityBase);e.Customer=r}(e=t.domain||(t.domain={}))}(app||(app={}));var app;!function(t){var e;!function(t){var e=function(){function t(){}return t}();t.EntityBase=e}(e=t.domain||(t.domain={}))}(app||(app={}));var app;!function(t){var e;!function(t){var e=function(){function t(t,e,r){this.$location=t,this.constantsService=e,this.dataService=r;var o=this;o.resource=o.constantsService.baseUri+this.constantsService.postUri}return t.prototype.add=function(){var t=this,e=this.constantsService.baseUri+this.constantsService.postUri;this.dataService.add(e,this.customer).then(function(e){alert(e.CustomerId+" submitted successfully"),t.$location.path("/")})},t.$inject=["$location","constantsService","dataService"],t}();angular.module("sampleAngularApp").controller("customerAddCtrl",e)}(e=t.postAdd||(t.postAdd={}))}(app||(app={}));var app;!function(t){var e;!function(e){var r=function(){function t(t,e){this.$modalInstance=t,this.customer=e,this.modalCustomer=e}return t.prototype.ok=function(){this.$modalInstance.close(this.modalCustomer)},t.prototype.cancel=function(){this.$modalInstance.dismiss("cancel")},t.controllerId="customerModalCtrl",t.$inject=["$modalInstance","customer"],t}();e.CustomerModalCtrl=r,angular.module("sampleAngularApp").controller("customerModalCtrl",t.customers.CustomerModalCtrl)}(e=t.customers||(t.customers={}))}(app||(app={}));var app;!function(t){var e;!function(e){var r=function(){function t(t,e,r,o){this.$scope=t,this.constantsService=e,this.dataService=r,this.$modal=o;var s=this;this.resource=e.baseUri+e.postUri,s.page=0,s.pagesCount=5,s.totalCount=0,this.scope=t,s.Customers=[],s.getCustomers(!0)}return t.prototype.search=function(){},t.prototype.refresh=function(){alert("length:"+this.Customers.length),this.getCustomers(!0)},t.prototype.getCustomers=function(t){var e=this,r=this;this.loadingCustomers=!0,this.dataService.get(this.resource,t).then(function(t){if(0==e.Customers.length)e.Customers=t;else{if(null!=t)for(var o=0;o<t.length;o++)r.Customers[o].CustomerId==t[o].CustomerId?r.Customers[o]=t[o]:r.Customers.push(t[o]);e.loadingCustomers=!1,e.totalCount=r.Customers.length,alert("retreived:"+r.Customers.length)}})},t.prototype.getCustomersById=function(t){var e=this;this.dataService.getSingle(this.resource+t).then(function(t){e.customer=t})},t.prototype.saveCustomer=function(t){var e=this;this.dataService.add(this.resource,t).then(function(r){e.Customers.push(t),e.getCustomers(!0)},function(t){console.log(t)})},t.prototype.updateCustomer=function(t){var e=this;this.dataService.update(this.resource,t).then(function(t){},function(t){e.getCustomers(!0),console.log(t)})},t.prototype.deleteCustomer=function(t){var e=this;this.dataService.remove(this.resource+t).then(function(r){for(var o=0;o<e.Customers.length;o++)if(e.Customers[o].CustomerId==t)return void e.Customers.splice(o,1);e.getCustomers(!0)})},t.prototype.remove=function(t){var e=this;confirm("Are you sure you want to delete this customer?")&&(e.deleteCustomer(t),e.getCustomers(!0))},t.prototype.add=function(){var t=this,e=this,r={animation:!0,templateUrl:"app/templates/customers/addCustomerView.html",controller:"customerModalCtrl",controllerAs:"modal",size:"lg",backdrop:"static",resolve:{customer:function(){return t.customer}}};this.$modal.open(r).result.then(function(t){null!=t&&(e.saveCustomer(t),e.getCustomers(!0))},function(t){})},t.prototype.edit=function(t){var e=this,r={animation:!0,templateUrl:"app/templates/customers/addCustomerView.html",controller:"customerModalCtrl",controllerAs:"modal",size:"lg",backdrop:"static",resolve:{customer:function(){return t}}};this.$modal.open(r).result.then(function(t){null!=t&&e.updateCustomer(t)})},t.$inject=["$scope","constantsService","dataService","$modal"],t}();e.CustomersCtrl=r,angular.module("sampleAngularApp").controller("CustomersCtrl",t.customers.CustomersCtrl)}(e=t.customers||(t.customers={}))}(app||(app={}));
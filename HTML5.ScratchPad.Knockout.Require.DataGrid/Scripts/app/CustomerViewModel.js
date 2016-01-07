//The model definition for jQuery and knockout dependencies
define("jquery", function () {
    return $;
});

define("knockout", function () {
    return ko;
})

/*The Customer View Model definition

We define a module as they are a well defined/scoped object that helps us avoid polluting the Global Namespace
A module can list it's dependencies and get a handle on them without using/referring to global objects
Instead it receives the dependencies as arguments to the function that defines the module
Modules in RequireJS follow the Module Pattern, this syntax allows multiple modules to be loaded, as fast as possible, even out of 
order through dependency injection
Each dependency is a module (in a file), and exists in our Scripts folder.
The 3 arguments are executed asynchronously first and then the function executes once they have loaded, 
but there could be.
This stops us from having to declare global objects

Note: Here we are defining a module as a Function with Dependencies

Modules dont need to have a return value,
We have a return cvalue here, which is the CustomerViewModel, hence this module defines the customer view model in 
our application
*/
define("CustomerViewModel", ['jquery', 'knockout', 'WebApiClient'], function ($, ko, apiClient) {

    var CustomerViewModel = function () {
        var self = this;

        //Boolean flag to check wheather the current operation is for 
        //Edit and add  New Record
        var isNewRecord = false;
        //Create a new instance of webApiClient
        var webapiClient = new apiClient;

        //1625 : 2000
        var uri = "http://localhost:1625/api/customer/";

        configureRequest = function (xhr) {
            authToken = "SessionToken"
            xhr.setRequestHeader("Authorization", "Session " + authToken);
        };

        createUri = function (path) {
            var baseUri = "http://localhost:1625";
            return baseUri + "/" + path;
        };


        /*Observables for app*/
        self.Message = ko.observable();

        //Observable Array for Customers
        self.Customers = ko.observableArray([]);

        //The Customer Object used for Add, Edit, Delete operations
        function CustomerModel(customerId, firstname, surname, addressline1, addressline2, addressline3, addressline4, postcode) {
            return {
                CustomerId: ko.observable(customerId),
                FirstName: ko.observable(firstname),
                Surname: ko.observable(surname),
                AddressLine1: ko.observable(addressline1),
                AddressLine2: ko.observable(addressline2),
                AddressLine3: ko.observable(addressline3),
                AddressLine4: ko.observable(addressline4),
                Postcode: ko.observable(postcode)
            }
        };

        //Observables for Templates
        self.readonlyTemplate = ko.observable("readonlyTemplate"),
        self.editTemplate = ko.observable()

        //Load customers by default
        GetCustomers();


        //Observable Functions to set the Template      
        self.setCurrentTemplate = function (tmpl) {
            return tmpl === this.editTemplate() ? 'editTemplate' : this.readonlyTemplate();
        }.bind(self);

        //Function to cancel edit effect
        self.reset = function (t) {
            self.editTemplate("readonlyTemplate");
        };

        //Function to add a new Empty row in table
        self.addRecord = function () {
            self.Customers.push(new CustomerModel(0, "", "", "", "", "", "", ""));
            isNewRecord = true; //Set the Check for the New Record
        };

        self.refreshRecords = function () {
            GetCustomers();
        };

        function MapCustomerModelFromCustomerDto(customers) {

            var mappedCustomers = []

            //Map CustomerDto to CustomerModel
            if (customers !== null && customers !==undefined) {

                $.each(customers, function (i) {
                    mappedCustomers.push(
                        new CustomerModel(
                        customers[i].CustomerId,
                        customers[i].FirstName,
                        customers[i].Surname,
                        customers[i].Address.AddressLine1,
                        customers[i].Address.AddressLine2,
                        customers[i].Address.AddressLine3,
                        customers[i].Address.AddressLine4,
                        customers[i].Address.Postcode
                        ))
                });
            }
            return mappedCustomers;
        };

        function MapCustomerModelToCustomerDto(model) {
            
            var customerDto = new function () { };
            var address = new function () { };

            address.AddressLine1 = model.AddressLine1;
            address.AddressLine2 = model.AddressLine2;
            address.AddressLine3 = model.AddressLine3;
            address.AddressLine4 = model.AddressLine4;
            address.Postcode = model.Postcode;

            customerDto.CustomerId = model.CustomerId;
            customerDto.FirstName = model.FirstName;
            customerDto.Surname = model.Surname;
            customerDto.Address = address;

            return customerDto;
        };

        //Function to Load Data using WEB API
        function GetCustomers() {

            //Call Ajax request
            webapiClient.get_All("api/customer/")
                .done(function (data) {
                    if (data !== null) {
                        //Map the response (CustomerDto) in an array of flattened Customer View objects 

                        //var mappedCustsFullStack = ko.observableArray(ko.utils.arrayMap(data, function (Customer) {
                        //    return {
                        //        FirstName: Customer.FirstName, Surname: Customer.Surname,
                        //        Address: ko.observable(ko.utils.map(Customer.Address, function(Address) {
                        //            return {
                        //                AddressId: Address.AddressId, 
                        //                AddressLine1: Address.AddressLine1,
                        //                AddressLine1: Address.AddressLine2,
                        //                AddressLine1: Address.AddressLine3,
                        //                AddressLine1: Address.AddressLine4,
                        //                Postcode: Address.Postcode
                        //                }
                        //        }))
                        //    };
                        //        //Address: ko.observable(Customer.Address)
                        //        //Address: ko.observable(Customer.Address)
 
                        //}));


                        //self.Customers = ko.observableArray(ko.utils.arrayMap(data, function (item) {

                        //    //var childAddress = function (item) {
                        //    //    ko.mapping.fromJS(item.Address, {}, this)
                        //    //};

                        //    var dataAddress = item.Address;
                        //    var newAddress =  new Address(
                        //        dataAddress.AddressId,
                        //        dataAddress.AddressLine1,
                        //        dataAddress.AddressLine2,
                        //        dataAddress.AddressLine3,
                        //        dataAddress.AddressLine4,
                        //        dataAddress.Postcode
                        //        );

                        //    return new Customer (
                        //        item.CustomerId, item.FirstName, item.Surname
                        //    );
                        //}));

                        //var mappedCustomers = ko.mapping.fromJS(data, function (item) { CustomerModel(item) });

                        //customersDto = ko.mapping.fromJS(data, {}, this)

                        var mappedCustomers = MapCustomerModelFromCustomerDto(data);
                        //Put the mapped response into an observable array
                        self.Customers(mappedCustomers.sort());
                    }
                }).fail(function (jqXHR, err) {
                    alert("An error occurred loading customers: " + err.status)
                    self.Message("Error " + err.status);
                    self.reset();
                });

            //self.Customers.sortByProperty("CustomerId");
        };


        //Function to save record
        self.save = function (e) {

            var customer = MapCustomerModelToCustomerDto(e);
            var controller = "api/customer/";

            if (isNewRecord === false) {

                webapiClient.put(controller, customer)
                    .done(function (resp) {
                        alert("Record Updated Successfully ");
                        self.Message("Record Updated Successfully ");
                        self.reset();
                        GetCustomers();
                    })
                    .fail(function (err) {
                        self.Message("Error Occurred, Please Reload the Page and Try Again " + err.status + " : " + err.responseText);
                        self.reset();
                    });
            }

            if (isNewRecord === true) {
                isNewRecord = false;

                webapiClient.post(controller, customer)
                    .done(function (resp) {
                        alert("Record added successfully");
                        self.Message("Record Added Successfully ");
                        self.reset();
                        GetCustomers();

                    }).fail(function (jqXHR, err) {
                        alert("Error Occurs, Please Reload the Page and Try Again " + err.status);
                        self.Message("Error Occurred, Please Reload the Page and Try Again " + err.status + " : " + err.responseText);
                        self.Customers.remove(customer);
                        //self.reset();

                    });
            }
        };

        //Function to Delete the Record
        self.delete = function (d) {

            var customer = MapCustomerModelToCustomerDto(d);
            var controller = "api/customer/";
 
            webapiClient.delete(controller, customer, d.CustomerId())
                .done(function (response) {
                    alert("Record Deleted successfully");
                    self.Message("Record deleted Successfully");
                    self.reset();
                    self.Customers.remove(customer);
                    GetCustomers();

            }).fail(function (jqXHR, err) {
                alert("Request failed. Please Reload the Page and Try Again " + err.status);
                self.Message("Error occurred, Please Reload the Page and Try Again " + err.status);
                self.reset();

            }).always(function () {
                //alert("complete");
              });

        };

        //ko.observableArray.fn.sortByProperty = function (prop) {
        //    this.sort(function (obj1, obj2) {
        //        if (obj1[prop] == obj2[prop])
        //            return 0;
        //        else if (obj1[prop] < obj2[prop])
        //            return -1;
        //        else
        //            return 1;
        //    });
        //}
    };





    //ko.observableArray.fn.sortByProperty = function (prop) {
    //    this.sort(function (obj1, obj2) {
    //        if (obj1[prop] == obj2[prop])
    //            return 0;
    //        else if (obj1[prop] < obj2[prop])
    //            return -1;
    //        else
    //            return 1;
    //    });
    //}

    //var addressMapping = {
    //    'Address': {
    //        key: function (data) {
    //            return ko.utils.unwrapObservable(data.Address);;
    //        }
    //    }
    //}

    ////var addressMapping = {
    ////    'Address': {
    ////        create: function (options) {
    ////            return Address(options.data);
    ////        }
    ////    }
    ////}

    //function Address(data) {
    //    ko.mapping.fromJS(data, {}, this);
    //}

    //function CustomersView(data) {
    //    var customers = ko.mapping.fromJS(data, addressMapping, this);
    //    return customers;
    //}



    return new CustomerViewModel();

    /*
    The above script code defines well-scoped objects for jQuery as $ and ko for knockout using define() function. 
    The file then defines ViewModel, this is knockout ViewModel having dependencies on jQuery for ajax calls 
    and Knockout for observable and observable arrays. 
    This ViewModel contains loadData () function for retrieving Employees data from WEB API using Ajax call. 
    The Customer object is used for performing CRUD operations. Since we will be using HTML table for CRUD operations, 
    we need to define Html templates for Row Adding and editing. To set the edit and read only template, 
    the ViewModel contains setCurrentTemplate () function. The function addRecord () pushes a new Customer
    object in the Customer observable array. 
    The save () and delete () functions are used for add, edit and delete operations using Ajax calls.
    */
});
using HTML5.ScratchPad.DDD.WebServices.ServiceReferences;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.WebServices.DataContracts;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;
using HTML5.ScratchPad.DDD.Infra.Data.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http.Description;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System;
using System.Web.Http.Cors;
using System.Threading;
using System.Text;

namespace HTML5.ScratchPad.DDD.WebServices.Controllers
{
    //[RoutePrefix("Customers")]
    //[EnableCors(origins: "http://localhost:*", headers: "*", methods: "*")]

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    //[RequireHttps]

    //[AllowCorsPolicy]
    public class CustomerController : ApiController, IServiceReferences
    {
        private ICustomerRepository _customerRepository;

        public CustomerController() { }

        public CustomerController(ICustomerRepository customerRepository)
        {
            if (customerRepository == null) _customerRepository = new CustomerRepository();
            _customerRepository = customerRepository;
        }

        //call with http://localhost:1625/api/customer
        /// <summary>
        /// Asynchronously gets all customer data and address details using Lazy loading.
        /// </summary>

        [HttpOptions]
        [HttpGet]
        [ResponseType(typeof(CustomerDto))]
        public async Task<HttpResponseMessage> GetAllCustomersAsync()
        {
            //_customerRepository = new CustomerRepository();
            var dbCustomers = _customerRepository.GetAllEager();

            //map response to DTO
            var customersDto = dbCustomers.Select(r =>
                 new CustomerDto()
                 {
                     CustomerId = r.CustomerId,
                     FirstName = r.FirstName,
                     Surname = r.Surname,
                     Active = r.Active,
                     InceptionDate = r.InceptionDate,
                     Address = new AddressDto
                     {
                         AddressLine1 = r.Address.AddressLine1,
                         AddressLine2 = r.Address.AddressLine2,
                         AddressLine3 = r.Address.AddressLine3,
                         AddressLine4 = r.Address.AddressLine4,
                         Postcode = r.Address.Postcode
                     },
                 });
          

            if (customersDto == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Customers");
            }
            //return Request.CreateResponse(HttpStatusCode.OK, customers);

            return Request.CreateResponse(HttpStatusCode.OK, customersDto.OrderByDescending(c => c.Surname).AsQueryable());

        }

        /// <summary>
        /// Asynchronously looks up customer and address data using int CustomerId.
        /// </summary>
        /// <param name="id">The customerid of the data.</param>
        //call with http://localhost:1625/api/customer/GetCustomerByIdAsync?customerId=1
        [HttpGet]
        [HttpOptions]
        [ResponseType(typeof(Customer))]
        public async Task<HttpResponseMessage> GetCustomerByIdAsync(int customerId)
        {
            var response = _customerRepository.GetById(customerId);
            if (response == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid CustomerId");
            }

            CustomerDto customerDto;

            try
            {
                //AutoMapper
                customerDto = Mapper.Map<Customer, CustomerDto>(response);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Customer could not be mapped to Dto");
            }
            return Request.CreateResponse(HttpStatusCode.OK, customerDto);
        }

        [HttpPost]
        [HttpOptions]
        public async Task<HttpResponseMessage> PostCreateCustomersAsync(CustomerDto customerDto)
        {
            if(customerDto == null)
            {
                throw new ArgumentNullException();
            }

            try
            { 
                //AutoMapper
                //var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

                Customer customer;
                
                customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    Surname = customerDto.Surname,
                    Active = true,
                };

                _customerRepository.Insert(customer);

                Address address;
                address = new Address
                {
                    AddressId = customer.CustomerId,
                    AddressLine1 = customerDto.Address.AddressLine1,
                    AddressLine2 = customerDto.Address.AddressLine2,
                    AddressLine3 = customerDto.Address.AddressLine3,
                    AddressLine4 = customerDto.Address.AddressLine4,
                    Postcode = customerDto.Address.Postcode
                };
                address.AddressId = customer.CustomerId;
                customer.Address = address;
                customer.AddressId = customer.CustomerId;
                _customerRepository.Update(customer);

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Customer could not be created");
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [HttpOptions]
        public async Task<HttpResponseMessage> PutUpdateCustomersAsync(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                //AutoMapper
                //var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                //Need to do it manually get automapper working later

                Customer customer;
                Address address;

                var originalCustomer = _customerRepository.GetById(customerDto.CustomerId);

                originalCustomer.FirstName = customerDto.FirstName;
                originalCustomer.Surname = customerDto.Surname;
                originalCustomer.Active = customerDto.Active;

                originalCustomer.Address.AddressLine1 = customerDto.Address.AddressLine1;
                originalCustomer.Address.AddressLine2 = customerDto.Address.AddressLine2;
                originalCustomer.Address.AddressLine3 = customerDto.Address.AddressLine3;
                originalCustomer.Address.AddressLine4 = customerDto.Address.AddressLine4;
                originalCustomer.Address.Postcode = customerDto.Address.Postcode;
                originalCustomer.Address.Customer = originalCustomer;

                var inceptionDate = customerDto.InceptionDate;

                //address = new Address
                //{
                //    AddressId = customerDto.CustomerId,
                //    AddressLine1 = customerDto.Address.AddressLine1,
                //    AddressLine2 = customerDto.Address.AddressLine2,
                //    AddressLine3 = customerDto.Address.AddressLine3,
                //    AddressLine4 = customerDto.Address.AddressLine4,
                //    Postcode = customerDto.Address.Postcode
                //};
                //customer = new Customer
                //{
                //    Address = address,
                //    CustomerId = customerDto.CustomerId,
                //    FirstName = customerDto.FirstName,
                //    Surname = customerDto.Surname,
                //    InceptionDate = (DateTime)inceptionDate,
                //    Active = true,
                //    AddressId = customerDto.CustomerId,
                //    RowVersion = customerDto.RowVersion
                //};

                //_customerRepository.Update(customer);
                _customerRepository.Update(originalCustomer);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Customer could not be updated: " + ex.InnerException);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE api/customer/5
        [HttpDelete]
        [HttpOptions]
        public async Task<HttpResponseMessage> DeleteCustomersByIdAsync(int id)
        { 
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid CustomerId");
            }
            try
            {
                //_customerRepository.DeleteById(customerId);
                _customerRepository.Delete(customer);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Customer could not be deleted: " + ex.InnerException);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}

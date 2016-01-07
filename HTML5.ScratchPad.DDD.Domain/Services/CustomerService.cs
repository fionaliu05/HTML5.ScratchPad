using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Services;
using System.Linq;

namespace HTML5.ScratchPad.DDD.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        //ICustomerRepository needs to be injected
        public CustomerService(ICustomerRepository customerRepository) 
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetSpecialCustomers(IEnumerable<Customer> customers) 
        {
            return customers.Where(c => c.SpecialCustomer(c));
        }
    }
}

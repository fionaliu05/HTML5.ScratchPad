using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Services;
using HTML5.ScratchPad.DDD.Application.Interfaces;

namespace HTML5.ScratchPad.DDD.Application
{
    public class CustomerAppService : AppServiceBase<Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        // ICustomerService needs to be injected
        public CustomerAppService(ICustomerService service)
            : base(service)
        {
            _customerService = service;
        }

        public IEnumerable<Customer> GetSpecialCustomers()
        {
            return _customerService.GetSpecialCustomers(_customerService.GetAll());
        }
    }
}

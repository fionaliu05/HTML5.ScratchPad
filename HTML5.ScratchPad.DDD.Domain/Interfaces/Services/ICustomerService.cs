using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Domain.Interfaces.Services
{ 
    public interface ICustomerService : IServiceBase<Customer>
    {
        IEnumerable<Customer> GetSpecialCustomers(IEnumerable<Customer> specialCustomers);
    }
}

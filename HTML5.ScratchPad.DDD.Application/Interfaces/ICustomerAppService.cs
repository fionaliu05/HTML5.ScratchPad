using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Application.Interfaces
{
    public interface ICustomerAppService : IAppServiceBase<Customer>
    {
        IEnumerable<Customer> GetSpecialCustomers();
    }
}

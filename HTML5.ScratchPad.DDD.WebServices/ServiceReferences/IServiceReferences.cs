using HTML5.ScratchPad.DDD.WebServices.DataContracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTML5.ScratchPad.DDD.WebServices.ServiceReferences
{
    public interface IServiceReferences
    {
        Task<HttpResponseMessage> GetCustomerByIdAsync(int customerId);
        Task<HttpResponseMessage> GetAllCustomersAsync();
        Task<HttpResponseMessage> PostCreateCustomersAsync(CustomerDto customer);
        Task<HttpResponseMessage> DeleteCustomersByIdAsync(int customerId);
    }
}

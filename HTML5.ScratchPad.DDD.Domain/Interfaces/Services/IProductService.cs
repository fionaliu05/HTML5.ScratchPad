using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> GetProductByName(string name);
    }
}

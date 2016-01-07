using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Application.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> GetProductByName(string name);
    }
}

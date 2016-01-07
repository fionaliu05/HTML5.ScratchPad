using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Collections.Generic;

namespace HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetProductByName(string name);
    }
}

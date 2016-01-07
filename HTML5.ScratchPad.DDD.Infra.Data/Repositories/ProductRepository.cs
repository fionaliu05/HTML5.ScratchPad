using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Domain.Entities;
using System.Linq;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;

namespace HTML5.ScratchPad.DDD.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> GetProductByName(string name)
        {
            return _context.Products.Where(p => p.Name == name);
        }

        public IEnumerable<Product> GetProductByCustomer(string name)
        {
            var products = _context.Products
                                .Where(p => p.Name == name)
                                .GroupBy(p => p.CustomerId)
                                .Select(o => o.OrderBy(p => p.ProductId).ThenBy(n => n.Name));

            return (IEnumerable<Product>) products;
        }
    }
}


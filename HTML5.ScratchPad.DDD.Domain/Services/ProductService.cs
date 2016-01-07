using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Services;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Repositories;

namespace HTML5.ScratchPad.DDD.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        //IProductRepository needs to be injected
        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }
    }
}

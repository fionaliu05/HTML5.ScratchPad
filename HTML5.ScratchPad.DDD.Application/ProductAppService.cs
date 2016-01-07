using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Application.Interfaces;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.Domain.Interfaces.Services;

namespace HTML5.ScratchPad.DDD.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        public readonly IProductService _productService;

        //IProductService Needs to be injected
        public ProductAppService(IProductService productService) 
            : base(productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return _productService.GetProductByName(name);
        }
    }
}

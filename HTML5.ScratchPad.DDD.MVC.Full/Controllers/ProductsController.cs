using AutoMapper;
using HTML5.ScratchPad.DDD.Application.Interfaces;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.MVC.Full.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HTML5.ScratchPad.DDD.MVC.Full.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private readonly IProductAppService _productAppService;
        private readonly ICustomerAppService _customerAppService;

        public ProductsController(IProductAppService productApp, ICustomerAppService customerApp)
        {
            _productAppService = productApp;
            _customerAppService = customerApp;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productAppService.GetAll());

            return View(productViewModel);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var product = _productAppService.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            return View(productViewModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            //SelectList needs a key value pair for the Key, and the Value to get from the list
            ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "CustomerId");
            //ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "Surname");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productAppService.Add(produtoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "CustomerId", product.CustomerId);
            //ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "Surname", product.CustomerId);
            return View(product);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productAppService.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "CustomerId", product.CustomerId);
            //ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "Surname", productViewModel.CustomerId);

            return View(productViewModel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productAppService.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_customerAppService.GetAll(), "CustomerId", "CustomerId", product.CustomerId);
            return View(product);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productAppService.GetById(id);
            var produtoViewModel = Mapper.Map<Product, ProductViewModel>(product);

            return View(produtoViewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productAppService.GetById(id);
            _productAppService.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
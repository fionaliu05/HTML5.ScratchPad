using System.Web.Mvc;
using AutoMapper;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.MVC.Full.Models;
using System.Collections.Generic;
using HTML5.ScratchPad.DDD.Application.Interfaces;

namespace HTML5.ScratchPad.DDD.MVC.Full.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerService)
        {
            _customerAppService = customerService;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customerDomain = _customerAppService.GetAll();
            var customerViewModel =
                Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customerDomain);
            return View(customerViewModel);
        }

        // GET: Special Customers
        public ActionResult Special()
        {
            var customerViewModel =
                Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_customerAppService.GetSpecialCustomers());
            return View(customerViewModel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerAppService.GetById(id);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                //Could do with an adapter
                var customerDomain = Mapper.Map<CustomerViewModel, Customer>(customerViewModel);
                _customerAppService.Add(customerDomain);
                RedirectToAction("Index");
            }
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerAppService.GetById(id);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                //Could do with an adapter
                var customerDomain = Mapper.Map<CustomerViewModel, Customer>(customerViewModel);
                _customerAppService.Update(customerDomain);
                RedirectToAction("Index");
            }
            return View(customerViewModel);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerAppService.GetById(id);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _customerAppService.GetById(id);
            _customerAppService.Remove(customer);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;
using AtencionClienteMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtencionClienteMVC.Controllers
{
    public class CustomerSupportController : Controller
    {
        private ICustomerSupportRepository _repository;

        public CustomerSupportController(ICustomerSupportRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IActionResult Index() {
            var customerSupportList = _repository.SearchAll();

            var customerSupportViewModelList = new List<CustomerSupportViewModel>();

            foreach (var item in customerSupportList) {
                customerSupportViewModelList.Add(new CustomerSupportViewModel()
                {
                    Id = item.Id,
                    Name=item.Name,
                    LastName = item.LastName,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    Genre = item.Genre,
                    Reason = item.Reason,
                    ContactDate = item.ContactDate
                });
            }

            return View(customerSupportViewModelList);
        }

        
        public IActionResult AddOrEdit(Guid id)
        {
            var customerSupport = _repository.SearchByID(id);
            if (customerSupport != null)
            return View(new CustomerSupportViewModel() {
                Id = customerSupport.Id,
                Name = customerSupport.Name,
                LastName = customerSupport.LastName,
                Mobile = customerSupport.Mobile,
                Email = customerSupport.Email,
                Genre = customerSupport.Genre,
                Reason = customerSupport.Reason,
                ContactDate = customerSupport.ContactDate
            });

            return View();
        }

        [HttpPost]
        public IActionResult AddOrEdit(CustomerSupportViewModel model) {
            if (!ModelState.IsValid)
                return View(); //retornar error

            var result = _repository.ExistsCustomerSupport(model.Id);

            if (!result)
            {
                _repository.Save(new CustomerSupport()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Genre = model.Genre,
                    Reason = model.Reason,
                    ContactDate = DateTime.Now
                });
            }
            else {
                _repository.Update(new CustomerSupport()
                {
                    Id = model.Id,
                    Name = model.Name,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Genre = model.Genre,
                    Reason = model.Reason,
                    ContactDate = model.ContactDate
                });
            }

            
            //return View();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id) {
            var result = _repository.ExistsCustomerSupport(id);
            if (result) {
                _repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


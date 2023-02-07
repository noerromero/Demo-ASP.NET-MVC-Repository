using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;
using AtencionClienteMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtencionClienteMVC.Controllers
{
    public class CustomerSupportController : Controller
    {
        private ICustomerSupportRepository _customerSupportRepository;
        private IGenderRepository _genderRepository;
        private IReasonRepository _reasonRepository;

        public CustomerSupportController(ICustomerSupportRepository customerSupportRepository
                                        , IGenderRepository genderRepository
                                        , IReasonRepository reasonRepository) {
            _customerSupportRepository = customerSupportRepository ?? throw new ArgumentNullException(nameof(customerSupportRepository));
            _genderRepository = genderRepository ?? throw new ArgumentNullException(nameof(genderRepository));
            _reasonRepository = reasonRepository ?? throw new ArgumentNullException(nameof(reasonRepository));
        }

        public IActionResult Index() {
            var customerSupportList = _customerSupportRepository.SearchAll();

            //var customerSupportViewModelList = new List<CustomerSupportViewModel>();
            var genders = _genderRepository.SearchAll();
            var reasons = _reasonRepository.SearchAll();

            var customerSupportViewModelList = from customerSupport in customerSupportList
                                               join gender in genders on customerSupport.Gender equals gender.Id
                                               join reason in reasons on customerSupport.Reason equals reason.Id
                                               select
                                                new CustomerSupportResponseViewModel()
                                                {
                                                    Id = customerSupport.Id,
                                                    Name = customerSupport.Name,
                                                    LastName = customerSupport.LastName,
                                                    Mobile = customerSupport.Mobile,
                                                    Email = customerSupport.Email,
                                                    Gender = gender.Description,
                                                    Reason = reason.Description,
                                                    ContactDate = customerSupport.ContactDate
                                                };
                               
            /*
            foreach (var item in customerSupportList) {
                customerSupportViewModelList.Add(new CustomerSupportViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    LastName = item.LastName,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    Gender = item.Gender,
                    Reason = item.Reason,
                    ContactDate = item.ContactDate
                });
            }
            */

            return View(customerSupportViewModelList);
        }

        [HttpGet]
        public IActionResult AddOrEdit(Guid id)
        {
            var customerSupport = _customerSupportRepository.SearchByID(id);
            CustomerSupportMultipleViewModel model = new CustomerSupportMultipleViewModel();

            model.genders = GetGenders();
            model.reasons = GetReasons();

            if (customerSupport != null) {
                model.customerSupport = new CustomerSupportRequestViewModel()
                {
                    Id = customerSupport.Id,
                    Name = customerSupport.Name,
                    LastName = customerSupport.LastName,
                    Mobile = customerSupport.Mobile,
                    Email = customerSupport.Email,
                    Gender = customerSupport.Gender,
                    Reason = customerSupport.Reason,
                    ContactDate = customerSupport.ContactDate
                };

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddOrEdit(Guid? id, CustomerSupportMultipleViewModel model) {
            if (!ModelState.IsValid)
                return View(new CustomerSupportMultipleViewModel()
                {
                    genders = GetGenders(),
                    reasons = GetReasons()
                }); ;

            var result = _customerSupportRepository.SearchByID(id ?? Guid.Empty);

            if (result == null)
            {
                _customerSupportRepository.Save(new CustomerSupport()
                {
                    Id = Guid.NewGuid(),
                    Name = model.customerSupport.Name,
                    LastName = model.customerSupport.LastName,
                    Mobile = model.customerSupport.Mobile,
                    Email = model.customerSupport.Email,
                    Gender = model.customerSupport.Gender.Value,
                    Reason = model.customerSupport.Reason.Value,
                    ContactDate = DateTime.Now
                });
            }
            else {
                _customerSupportRepository.Update(new CustomerSupport()
                {
                    Id = result.Id,
                    Name = model.customerSupport.Name ?? result.Name ,
                    LastName = model.customerSupport.LastName ?? result.LastName,
                    Mobile = model.customerSupport.Mobile ?? result.Mobile,
                    Email = model.customerSupport.Email ?? result.Email,
                    Gender = model.customerSupport.Gender ?? result.Gender,
                    Reason = model.customerSupport.Reason ?? result.Reason,
                    ContactDate = model.customerSupport.ContactDate ?? result.ContactDate
                });
            }


            //return View();
            return RedirectToAction(nameof(Index));
        }

        

        public IActionResult Delete(Guid id) {
            var result = _customerSupportRepository.ExistsCustomerSupport(id);
            if (result) {
                _customerSupportRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetGenders() {
            var genreList = _genderRepository.SearchAll();
            var genderViewModelList = new List<SelectListItem>();

            foreach (var item in genreList) {
                genderViewModelList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Description });
            }
            return genderViewModelList;
        }

        private IEnumerable<SelectListItem> GetReasons()
        {
            var reasonList = _reasonRepository.SearchAll();
            var reasonViewModelList = new List<SelectListItem>();

            foreach (var item in reasonList)
            {
                reasonViewModelList.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Description });
            }
            return reasonViewModelList;
        }

    }
}


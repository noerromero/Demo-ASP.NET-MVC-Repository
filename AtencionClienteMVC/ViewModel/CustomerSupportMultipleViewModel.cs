using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtencionClienteMVC.ViewModel
{
	public class CustomerSupportMultipleViewModel
	{
		public CustomerSupportRequestViewModel?  customerSupport { get; set; }
		public IEnumerable<SelectListItem>? genders { get; set; }
		public IEnumerable<SelectListItem>? reasons { get; set; }
	}
}


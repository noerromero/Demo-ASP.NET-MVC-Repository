using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtencionClienteMVC.ViewModel
{
	public class AddOrEditMultipleViewModel
	{
		public PostCustomerSupportRequestViewModel?  customerSupport { get; set; }
		public IEnumerable<SelectListItem>? genders { get; set; }
		public IEnumerable<SelectListItem>? reasons { get; set; }
	}
}


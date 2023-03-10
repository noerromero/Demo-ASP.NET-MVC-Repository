using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;

namespace AtencionClienteMVC.Infrastructure.Persistence.InMemory
{
	public class InMemoryCustomerSupportRepository : ICustomerSupportRepository
	{
		private static List<CustomerSupport> _customerSupportList = new List<CustomerSupport>();

		public InMemoryCustomerSupportRepository()
		{

		}

		public void Save(CustomerSupport customerSupport) {
			_customerSupportList.Add(customerSupport);
		}

		public IEnumerable<CustomerSupport> SearchAll(DateTime? startDate, DateTime? endDate) {
            if (startDate == null && endDate == null)
                return _customerSupportList.ToList();
			return _customerSupportList
						.Where(x => x.ContactDate.Date >= startDate && x.ContactDate.Date <= endDate)
						.ToList();
		}

		public CustomerSupport? SearchByID(Guid id) {
			var customerSupport = _customerSupportList.FirstOrDefault(x => x.Id == id);
			return customerSupport;
		}

		public void Update(CustomerSupport customerSupport) {
            var customerSupportForUpdate = _customerSupportList.FirstOrDefault(x => x.Id == customerSupport.Id);
			if (customerSupportForUpdate != null) {
                customerSupportForUpdate.Name = customerSupport.Name;
				customerSupportForUpdate.LastName = customerSupport.LastName;
				customerSupportForUpdate.Mobile = customerSupport.Mobile;
				customerSupportForUpdate.Email = customerSupport.Email;
				customerSupportForUpdate.Gender = customerSupport.Gender;
				customerSupportForUpdate.Reason = customerSupport.Reason;
				
            }
				

        }

		public bool ExistsCustomerSupport(Guid id) {
            var customerSupport = _customerSupportList.FirstOrDefault(x => x.Id == id);
			if (customerSupport != null)
				return true;
			return false;
        }

		public void Delete(Guid id) {
			var customerSuppport = _customerSupportList.FirstOrDefault(x => x.Id == id);
			if (customerSuppport!=null)
				_customerSupportList.Remove(customerSuppport);
		}
    }
}


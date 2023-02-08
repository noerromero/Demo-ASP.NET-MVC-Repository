namespace AtencionClienteMVC.Models.Repository
{
	public interface ICustomerSupportRepository
	{
		void Save(CustomerSupport customerSupport);
        IEnumerable<CustomerSupport> SearchAll(DateTime? startDate, DateTime? endDate);
		CustomerSupport? SearchByID(Guid id);
		void Update(CustomerSupport customerSupport);
		bool ExistsCustomerSupport(Guid id);
		void Delete(Guid id);

	}
}


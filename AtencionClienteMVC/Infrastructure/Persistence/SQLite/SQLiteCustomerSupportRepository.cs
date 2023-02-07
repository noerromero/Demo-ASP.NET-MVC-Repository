
using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace AtencionClienteMVC.Infrastructure.Persistence.SQLite
{
	public class SQLiteCustomerSupportRepository : ICustomerSupportRepository
	{
        private Context _context;

        public SQLiteCustomerSupportRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        
        public void Delete(Guid id)
        {
            var customerSuppport = _context.customerSupports.FirstOrDefault(x => x.Id == id);
            if (customerSuppport != null)
                _context.customerSupports.Remove(customerSuppport);
            _context.SaveChangesAsync();
        }

        public bool ExistsCustomerSupport(Guid id)
        {
            return _context.customerSupports.Any(x => x.Id == id);
        }

        public void Save(CustomerSupport customerSupport)
        {
            _context.customerSupports.Add(customerSupport);
            _context.SaveChanges();
        }

        public IEnumerable<CustomerSupport> SearchAll()
        {
            return _context.customerSupports.ToList();
        }

        public CustomerSupport? SearchByID(Guid id)
        {
            var customerSupport = _context.customerSupports
                            .FirstOrDefault(x => x.Id == id);

            return customerSupport;
        }

        public void Update(CustomerSupport customerSupport)
        {
            var customerSupportForUpdate = _context.customerSupports.FirstOrDefault(x => x.Id == customerSupport.Id);
            if (customerSupportForUpdate != null) {
                customerSupportForUpdate.Name = customerSupport.Name;
                customerSupportForUpdate.LastName = customerSupport.LastName;
                customerSupportForUpdate.Mobile = customerSupport.Mobile;
                customerSupportForUpdate.Email = customerSupport.Email;
                customerSupportForUpdate.Gender = customerSupport.Gender;
                customerSupportForUpdate.Reason = customerSupport.Reason;

                _context.Entry(customerSupportForUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            
        }
    }
}


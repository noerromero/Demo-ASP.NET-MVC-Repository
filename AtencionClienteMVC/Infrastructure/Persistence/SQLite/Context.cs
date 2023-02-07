using AtencionClienteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AtencionClienteMVC.Infrastructure.Persistence.SQLite
{
    public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerSupport> customerSupports { get; set; }
    }
}


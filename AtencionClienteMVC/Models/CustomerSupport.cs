using System;
namespace AtencionClienteMVC.Models
{
	public class CustomerSupport
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime ContactDate { get; set; }
        
	}
}


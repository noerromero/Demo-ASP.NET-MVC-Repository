namespace AtencionClienteMVC.Models
{
    public class CustomerSupport
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Gender { get; set; } 
        public int Reason { get; set; } 
        public DateTime ContactDate { get; set; }
        
	}
}


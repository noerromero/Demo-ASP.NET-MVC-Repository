using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;

namespace AtencionClienteMVC.Infrastructure.Persistence.InMemory
{
    public class InMemoryGenderRepository : IGenderRepository
	{
		public InMemoryGenderRepository()
		{
		}

        public IEnumerable<Gender> SearchAll()
        {
            return new List<Gender>() {
                new Gender() { Id=1, Description="Masculino"},
                new Gender() { Id=2, Description="Femenino"}
            };
        }
    }
}


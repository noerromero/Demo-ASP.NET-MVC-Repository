using AtencionClienteMVC.Models;
using AtencionClienteMVC.Models.Repository;

namespace AtencionClienteMVC.Infrastructure.Persistence.InMemory
{
    public class InMemoryReasonRepository : IReasonRepository
	{
		public InMemoryReasonRepository()
		{
		}

        public IEnumerable<Reason> SearchAll()
        {
            return new List<Reason>() {
                new Reason() { Id=1, Description="Incidencia"},
                new Reason() { Id=2, Description="Queja"},
                new Reason() { Id=3, Description="Reclamación"},
                new Reason() { Id=4, Description="Sugerencia"}
            };
        }
    }
}


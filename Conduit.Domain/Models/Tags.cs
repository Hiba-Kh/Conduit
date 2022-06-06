using Conduit.Domain.Repositories;

namespace Conduit.Domain.Models
{
    public class Tags : IDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Articles> Articles { get; set; }

    }
}

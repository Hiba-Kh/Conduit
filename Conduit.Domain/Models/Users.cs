using Conduit.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Conduit.Domain.Models
{
    public class Users : IdentityUser, IDomainModel
    {
        public Profiles Profile { get; set; }
        public List<Articles> Articles { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

using Conduit.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Conduit.Data.Models
{
    public class Users : IdentityUser<Guid>, IDbModel
    {
        public Profiles Profile { get; set; }
        public List<Articles> Articles { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Conduit.Domain.Models
{
    public class Users : IdentityUser
    {
        public Profiles Profile { get; set; }
        public List<Articles> Articles { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

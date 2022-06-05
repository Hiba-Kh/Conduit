using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Conduit.Data.Models
{
    public class Users : IdentityUser<Guid>
    {
        public Profiles Profile { get; set; }
        public List<Articles> Articles { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

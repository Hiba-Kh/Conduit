using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Domain.Models
{
    public class Profiles
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public bool Following { get; set; }
        public string UserId { get; set; }
        public Users User { get; set; }

    }
}

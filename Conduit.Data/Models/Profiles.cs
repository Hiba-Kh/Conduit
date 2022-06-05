using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Data.Models
{
    public class Profiles
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public bool Following { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }

    }
}

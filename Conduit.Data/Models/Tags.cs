using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Data.Models
{
    public class Tags
    {
        [Key]
        public Guid Id { get; set; }
        public List<Articles> Articles { get; set; }
    }
}

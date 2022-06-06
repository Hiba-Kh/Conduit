using System.ComponentModel.DataAnnotations;
using Conduit.Domain.Repositories;

namespace Conduit.Data.Models
{
    public class Profiles : IDbModel
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

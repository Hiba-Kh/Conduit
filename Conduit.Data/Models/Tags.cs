using System.ComponentModel.DataAnnotations;
using Conduit.Domain.Repositories;

namespace Conduit.Data.Models
{
    public class Tags : IDbModel
    {
        [Key]
        public Guid Id { get; set; }
        public List<Articles> Articles { get; set; }
    }
}

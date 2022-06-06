using System.ComponentModel.DataAnnotations;
using Conduit.Domain.Repositories;

namespace Conduit.Data.Models
{
    public class Comments : IDbModel
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public Users Author { get; set; }
        public Guid? ArticleId { get; set; }
        public Articles Article { get; set; }
    }
}

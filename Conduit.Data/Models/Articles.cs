using System.ComponentModel.DataAnnotations;
using Conduit.Domain.Repositories;

namespace Conduit.Data.Models
{
    public class Articles : IDbModel
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Key]
        [Required]
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Favorited { get; set; }
        public int FavoritesCount { get; set; }
        public string AuthorId { get; set; }
        public Users Author { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Tags> Tags { get; set; }

    }
}

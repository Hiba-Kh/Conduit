using Conduit.Domain.Repositories;

namespace Conduit.Domain.Models
{
    public class Articles : IDomainModel
    {
        public Guid Id { get; set; }
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

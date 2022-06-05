using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Data.Models
{
    public class Articles
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

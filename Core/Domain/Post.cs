using System;

namespace Domain
{
    public class Post : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
        
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
    }
}
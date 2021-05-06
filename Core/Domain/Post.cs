using System;

namespace Domain
{
    public class Post : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string[] Tags { get; set; }
        
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}
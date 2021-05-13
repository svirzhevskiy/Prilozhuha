using System;
using System.Collections.Generic;

namespace DTOs
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public Guid AuthorId { get; set; }
    }
}
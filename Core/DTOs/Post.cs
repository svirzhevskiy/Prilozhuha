using System;
using System.Collections.Generic;

namespace DTOs
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Tags { get; set; }
        
        public User Author { get; set; }
    }
}
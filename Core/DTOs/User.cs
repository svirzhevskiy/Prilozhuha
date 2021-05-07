using System;
using System.Collections.Generic;

namespace DTOs
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Role Role { get; set; } = null!;

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
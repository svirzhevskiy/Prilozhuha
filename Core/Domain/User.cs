using System;
using System.Collections.Generic;

namespace Domain
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
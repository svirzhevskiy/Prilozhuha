using System;

namespace Domain
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
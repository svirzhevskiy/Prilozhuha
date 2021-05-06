﻿using System;
using System.Collections.Generic;

namespace DTOs
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Role Role { get; set; }
        
        public List<Post> Posts { get; set; }
    }
}
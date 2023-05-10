﻿namespace AnimalRecognizer.Model
{
    public class User
    {
        public enum UserRole 
        { 
            Admin, 
            User 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int? RoleId { get; set; }

    }
}

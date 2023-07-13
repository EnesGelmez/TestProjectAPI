﻿namespace TestProjectAPI.Models
{
    public class AddUserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
    }
}

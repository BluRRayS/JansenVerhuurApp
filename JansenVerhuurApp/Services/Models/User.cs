﻿using Services.Enums;

namespace Services.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Role Role { get; set; }
    }
}
using System;

namespace UserService.Dtos
{
    public class LoginDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
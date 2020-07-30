using System;

namespace TibiaInfo.Infrastructure.Commands.Users
{
    public class Register
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
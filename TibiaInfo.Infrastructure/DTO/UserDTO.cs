using System;

namespace TibiaInfo.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set;}
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
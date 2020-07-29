using System;
using System.Collections.Generic;

namespace TibiaInfo.Core.Domain
{
    public class User : Entity
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<TibiaCharacter> TibiaCharacters;

    }
}
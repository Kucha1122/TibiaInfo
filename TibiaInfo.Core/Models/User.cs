using System;
using System.Collections.Generic;

namespace TibiaInfo.Core.Models
{
    public class User : Entity
    {
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }

        public IList<TibiaCharacter> TibiaCharacters { get; set; }

    }
}
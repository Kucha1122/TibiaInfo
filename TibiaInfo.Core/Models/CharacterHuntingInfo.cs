using System;

namespace TibiaInfo.Core.Models
{
    public class CharacterHuntingInfo : Entity
    {
        public string Nickname { get; set; }
        public Double Loot { get; set; }
        public Double Supplies { get; set; }
        public Double Balance { get; set; }
        public Double Damage { get; set; }
        public Double Healing { get; set; }
        
    }
}
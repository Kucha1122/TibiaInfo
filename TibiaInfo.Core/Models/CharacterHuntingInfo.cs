using System;
using System.Collections.Generic;

namespace TibiaInfo.Core.Models
{
    public class CharacterHuntingInfo : Entity
    {
        public Double PersonalLoot { get; set; }
        public Double PersonalSupplies { get; set; }
        public Double PersonalBalance { get; set; }
        public Double Damage { get; set; }
        public Double Healing { get; set; }

        public IList<Huntings> Huntings { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace TibiaInfo.Core.Models
{
    public class Hunting : Entity
    {
        public DateTime Session { get; set;}
        public Double Loot { get; set; }
        public Double Supplies { get; set; }
        public Double Balance { get; set; }

        public IList<CharacterHuntingInfo> CharacterHuntingInfos { get; set; }

    }
}
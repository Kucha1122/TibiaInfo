using System;

namespace TibiaInfo.Core.Models
{
    public class Huntings : Entity
    {
        public Guid TibiaCharacterId { get; set; }
        public TibiaCharacter TibiaCharacter { get; set; }
        public Guid CharacterHuntingInfoId { get; set; }
        public CharacterHuntingInfo CharacterHuntingInfo { get; set; }
        public Guid HuntingInfoId { get; set; }
        public HuntingInfo HuntingInfo { get; set; }
    }
}
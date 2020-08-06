using System;

namespace TibiaInfo.Infrastructure.DTO
{
    public class HuntingsDTO
    {
        public Guid TibiaCharacterId { get; set; }
        public Guid CharacterHuntingInfoId { get; set; }
        public Guid HuntingInfoId { get; set; }

    }
}
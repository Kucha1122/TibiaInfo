using System;

namespace TibiaInfo.Infrastructure.DTO
{
    public class HuntingInfoDTO
    {
        public DateTime Session { get; set; }
        public Double Loot { get; set; }
        public Double Supplies { get; set; }
        public Double Balance { get; set; }
    }
}
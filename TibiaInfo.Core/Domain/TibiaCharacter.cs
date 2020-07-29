using System;

namespace TibiaInfo.Core.Domain
{
    public class TibiaCharacter : Entity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Sex { get; set; }
        public string Vocation { get; set; }
        public int Level { get; set; }
        public int AchievementPoints { get; set; }
        public string World { get; set; }
        public string Residence { get; set; }
        public DateTime LastLogin { get; set; }
        public string AccountStatus { get; set; }
        public string LoyaltyTitle { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

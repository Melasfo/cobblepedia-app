namespace ProjectTrial11.Models
{
    public class BaseStat
    {
        public int Id { get; set; }
        public string CobblemonStatsName { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set;}
        public int Speed { get; set; }
        public int TotalStats { get; set; }
        public ICollection<CobblemonBaseStat>?CobblemonBaseStats { get; set; }
    }
}

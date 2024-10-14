namespace ProjectTrial11.Models
{
    public class CobblemonBaseStat
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int BaseStatId { get; set; }
        public BaseStat BaseStat { get; set; }
    }
}

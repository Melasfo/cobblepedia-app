namespace ProjectTrial11.Models
{
    public class CobblemonTMMove
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int TMMoveId { get; set; }
        public TMMove TMMove { get; set; }
    }
}

namespace ProjectTrial11.Models
{
    public class CobblemonEggMove
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int EggMoveId { get; set; }
        public EggMove EggMove { get; set; }
    }
}

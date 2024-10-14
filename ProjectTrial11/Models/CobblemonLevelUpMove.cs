namespace ProjectTrial11.Models
{
    public class CobblemonLevelUpMove
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int LevelUpMoveId { get; set; }
        public LevelUpMove LevelUpMove { get; set; }
    }
}

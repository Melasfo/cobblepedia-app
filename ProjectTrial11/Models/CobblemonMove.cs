namespace ProjectTrial11.Models
{
    public class CobblemonMove
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int MoveId { get; set; }
        public Move Move { get; set; }
    }
}

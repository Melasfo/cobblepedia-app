namespace ProjectTrial11.Models
{
    public class CobblemonLocation
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}

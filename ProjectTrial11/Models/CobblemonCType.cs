namespace ProjectTrial11.Models
{
    public class CobblemonCType
    {
        public int Id { get; set; }
        public int CobblemonId { get; set; }
        public Cobblemon Cobblemon { get; set; }
        public int CTypeId { get; set; }
        public CType CType { get; set; }
    }
}

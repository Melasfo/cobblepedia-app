namespace ProjectTrial11.Models
{
    public class CType
    {
        public int Id { get; set; }
        public string CTypeName { get; set; }
        public ICollection<CobblemonCType>? CobblemonCTypes { get; set; }
    }
}

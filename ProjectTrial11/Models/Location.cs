namespace ProjectTrial11.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Biome { get; set; }
        public string Time { get; set; }
        public string Weather { get; set; }
        public string Context { get; set; }
        public string Preset { get; set; }
        public string Rarity { get; set; }
        public string ?Requirements { get; set; }
        public ICollection<CobblemonLocation>? CobblemonLocations { get; set; }
    }
}

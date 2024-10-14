namespace ProjectTrial11.Models
{
    public class Cobblemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NationalDexNum { get; set; }
        public string Species { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Abilities { get; set; }
        public bool CanEvolve { get; set; }
        public string ?EvolutionMethod { get; set; }
        public string ImagePath { get; set; }

        public ICollection<CobblemonCType>?CobblemonCTypes { get; set; }
        public ICollection<CobblemonBaseStat>?CobblemonBaseStats { get; set; }
        public ICollection<CobblemonLevelUpMove>?CobblemonLevelUpMoves { get; set; }
        public ICollection<CobblemonTMMove>?CobblemonTMMoves { get; set; }
        public ICollection<CobblemonEggMove>?CobblemonEggMoves { get; set; }
        public ICollection<CobblemonLocation>?CobblemonLocations { get; set; }
        public ICollection<CobblemonMove>? CobblemonMoves { get; set; }
    }
}

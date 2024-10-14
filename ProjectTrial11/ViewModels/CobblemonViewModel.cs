namespace ProjectTrial11.ViewModels
{
    public class CobblemonViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NationalDexNum { get; set; }
        public string Species { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Abilities { get; set; }
        public bool CanEvolve { get; set; }
        public string ?EvolutionMethod { get; set; }
        public string? ImagePath { get; set; }
        public List<int> TMMoveIds { get; set; }
        public List<int> BaseStatIds { get; set; }
        public List<int> LevelUpMoveIds { get; set; }
        public List<int> ?EggMoveIds { get; set; }
        public List<int> CTypeIds { get; set; }
        public List<int> LocationIds { get; set; }
    }
}

namespace ProjectTrial11.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string MoveName { get; set; }
        public string MoveType { get; set; }
        public string MoveCategory { get; set; }
        public string MovePower { get; set; }
        public string MoveAccuracy { get; set; }
        public ICollection<CobblemonMove>? CobblemonMoves { get; set; }
    }
}

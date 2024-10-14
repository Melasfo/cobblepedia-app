namespace ProjectTrial11.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime  DatePosted { get; set; }
        public int ?Likes { get; set; }
        public int ?Dislikes { get; set; }
        public bool ?IsAnswered { get; set; }
        public ICollection<Comment> ?Comments { get; set; }
    }
}

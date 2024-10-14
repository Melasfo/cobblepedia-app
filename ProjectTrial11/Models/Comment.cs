namespace ProjectTrial11.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int ?Likes { get; set; }
        public int ?Dislikes { get; set; }
        public DateTime DatePosted { get; set; }
        public int ?QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}

namespace Quiz.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public Question Question { get; set; }

        public Option Option { get; set; }
    }
}
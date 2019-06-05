namespace Quiz.Data.Models
{
    using System.Collections.Generic;

    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<Option> Options { get; set; }

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}
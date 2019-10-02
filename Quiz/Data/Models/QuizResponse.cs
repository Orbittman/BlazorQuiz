using System.Collections.Generic;

namespace Quiz.Data.Models
{
    public class QuizResponse
    {
        public int Id { get; set; }

        public Quiz Quiz { get; set; }

        public int QuizId { get; set; }

        public string Person { get; set; }

        public string IpAddress { get; set; }

        public string Token { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}

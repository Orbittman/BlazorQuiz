namespace Quiz.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Quiz
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime EndTime { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
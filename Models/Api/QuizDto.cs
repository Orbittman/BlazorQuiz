namespace Models.Api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class QuizDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Needs a name fool!")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime EndTime { get; set; }

        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();

        public void Deconstruct(out int id, out string name, out DateTime date, out DateTime endTime)
        {
            id = Id;
            name = Name;
            date = Date;
            endTime = EndTime;
        }
    }
}
namespace Models.Api
{
    public class AnswerDto
    {
        public int Id { get; set; }

        public QuestionDto Question { get; set; }

        public OptionDto Option { get; set; }
    }
}
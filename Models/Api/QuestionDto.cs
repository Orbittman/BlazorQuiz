using System;
using System.Collections.Generic;

namespace Models.Api
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<OptionDto> Options { get; set; } = new List<OptionDto>();

        public Guid Key { get; set; } = Guid.NewGuid();
    }
}
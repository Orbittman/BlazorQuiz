using System;

namespace Models.Api
{
    public class OptionDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Answer { get; set; }

        public Guid Key { get; set; } = Guid.NewGuid();
    }
}
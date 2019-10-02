namespace Quiz.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public interface IQuizContext : IDisposable
    {
        DbSet<Quiz> Quizes { get; set; }

        DbSet<Answer> Answers { get; set; }

        DbSet<QuizResponse> Responses { get; set; }

        int SaveChanges();
    }
}

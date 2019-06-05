namespace Quiz.Data.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public interface IQuizContext : IDisposable
    {
        DbSet<Quiz> Quizes { get; set; }

        int SaveChanges();
    }
}

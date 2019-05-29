namespace Quiz.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    public class QuizContext : DbContext, IQuizContext
    {
        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Quiz.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(quiz => quiz.Questions)
                .WithOne(question => question.Quiz)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(question => question.Options)
                .WithOne(option => option.Question)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

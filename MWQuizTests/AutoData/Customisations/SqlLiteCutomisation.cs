namespace MWQuizTests.AutoData.Customisations
{
    using AutoFixture;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Quiz.Data.Models;

    public class SqlLiteCutomisation : ICustomization
    {
        public void Customize(IFixture fixture)
        {
           fixture.Register(BuildSqlConnection);
        }

        private IQuizContext BuildSqlConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<QuizContext>()
                .UseSqlite(connection)
                .Options;

            var context = new QuizContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}

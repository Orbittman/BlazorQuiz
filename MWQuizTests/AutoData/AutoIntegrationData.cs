namespace MWQuizTests.AutoData
{
    using AutoFixture.Xunit2;

    public class AutoIntegrationDataAttribute : AutoDataAttribute
    {
        public AutoIntegrationDataAttribute()
            : base(FixtureFactory.Create)
        {
        }
    }
}

namespace MWQuizTests.AutoData
{
    using System;
    using System.Linq;
    using AutoFixture;
    using AutoFixture.AutoNSubstitute;

    public static class FixtureFactory
    {
        public static Fixture Create()
        {
            var customizations = typeof(FixtureFactory).Assembly.GetTypes()
                .Where(t => typeof(ICustomization).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<ICustomization>()
                .ToList();

            var fixture = new Fixture();

            fixture.Customize(new AutoNSubstituteCustomization());

            customizations.ForEach(c => fixture.Customize(c));

            return fixture;
        }
    }
}
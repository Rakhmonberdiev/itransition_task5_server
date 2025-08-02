using Bogus;

namespace itransition_task5_server.Helpers
{
    public static class FakerFactory
    {
        public static Faker Create(string locale, int seed)
        {
            var faker = new Faker(locale);
            faker.Random = new Randomizer(seed);
            return faker;
        }
    }
}

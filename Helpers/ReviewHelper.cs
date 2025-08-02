using itransition_task5_server.DTOs;

namespace itransition_task5_server.Helpers
{
    public static class ReviewHelper
    {
        public static List<ReviewDto> Generate(string locale, int seed, double avgReviews)
        {
            int count = StochasticHelper.GetStochasticInt(seed, avgReviews);
            var faker = FakerFactory.Create(locale, seed + 1);

            return Enumerable.Range(0, count)
                .Select(_ => new ReviewDto
                {
                    Author = faker.Name.FullName(),
                    Text = faker.Lorem.Sentence()
                })
                .ToList();
        }
    }
}

using Bogus;
using itransition_task5_server.DTOs;
using itransition_task5_server.Helpers;

namespace itransition_task5_server.Services
{
    public class BookGenerator : IBookGenerator
    {
        public List<BookDto> GenerateBooks(BookRequestDto req)
        {
            var (skip, take) = PaginationHelper.Calculate(req.Page, req.PageSize, req.InitialPageSize);
            var books = new List<BookDto>(take);
            for(int i = 0; i < take; i++)
            {
                int globalIndex = skip + i + 1;
                int bookSeed = req.Seed + skip + i;
                var faker = FakerFactory.Create(req.Locale, bookSeed);
                var authors = faker.Make(faker.Random.Int(1, 2), () => faker.Name.FullName()).ToList();
                var isbn = faker.Random.Replace("978-#-###-#####-#");
                var title = faker.Lorem.Sentence(3);
                var publisher = faker.Company.CompanyName();
                int likes = StochasticHelper.GetStochasticInt(bookSeed + 2, req.AvgLikes);
                var reviews = ReviewHelper.Generate(req.Locale, bookSeed + 3, req.AvgReviews);
                var book = new BookDto
                {
                    Index = globalIndex,
                    ISBN = isbn,
                    Title = title,
                    Publisher = publisher,
                    Authors = authors,
                    Likes = likes,
                    Reviews = reviews
                };
                books.Add(book);
            }
            return books;
        }
    }
}

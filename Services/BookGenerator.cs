using Bogus;
using itransition_task5_server.DTOs;
using itransition_task5_server.Helpers;

namespace itransition_task5_server.Services
{
    public class BookGenerator : IBookGenerator
    {
        public List<BookDto> GenerateBooks(BookRequestDto req)
        {
            var (skip, take) = PaginationHelper.Calculate(req);
            var books = new List<BookDto>(take);
            for(int i = 0; i < take; i++)
            {
                int globalIndex = skip + i + 1;
                int bookSeed = req.Seed + skip + i;
                var faker = FakerFactory.Create(req.Locale, bookSeed);
                var authors = faker.Make(faker.Random.Int(1, 2), () => faker.Name.FullName()).ToList();
                var isbn = faker.Random.Replace("978-#-###-#####-#");
                var title = faker.Commerce.ProductName();
                var publisher = faker.Company.CompanyName();
                var reviews = ReviewHelper.Generate(req.Locale, bookSeed + 3, req.AvgReviews);
                int likes = StochasticHelper.GetStochasticInt(bookSeed + 2, req.AvgLikes);
           
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

using itransition_task5_server.DTOs;

namespace itransition_task5_server.Services
{
    public interface IBookGenerator
    {
        List<BookDto> GenerateBooks(BookRequestDto req);
    }
}

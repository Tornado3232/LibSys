

namespace LibSys.Services.BookService
{
    public interface IBookService
    {
        ServiceResponse<List<GetBookDto>> GetAllBooks();
        ServiceResponse<GetBookDto> GetBookById(int id);
        ServiceResponse<List<GetBookDto>> AddBook(AddBookDto newBook);
        ServiceResponse<GetBookDto> UpdateBook(UpdateBookDto updatedBook);
        ServiceResponse<List<GetBookDto>> DeleteBook(int id);
    }
}

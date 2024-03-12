
using LibSys.Models;
using System.Xml.Linq;

namespace LibSys.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ServiceResponse<List<GetBookDto>> AddBook(AddBookDto newBook)
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            
            var category = _context.Categories.FirstOrDefault(c => c.Id == newBook.Category.Id);
            var book = _mapper.Map<Book>(newBook);
            book.Category = category;
            _context.Books.Add(book);
            _context.SaveChanges();

            serviceResponse.Data = _context.Books.Select(b => _mapper.Map<GetBookDto>(b)).ToList();
            return serviceResponse;
        }

        public ServiceResponse<List<GetBookDto>> DeleteBook(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    throw new Exception($"Book with Id '{id}' not found!");
                }

                _context.Books.Remove(book);
                _context.SaveChanges();

                serviceResponse.Data = _context.Books.Select(b => _mapper.Map<GetBookDto>(b)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public ServiceResponse<List<GetBookDto>> GetAllBooks()
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            var dbBooks =  _context.Books.ToList();
            serviceResponse.Data = dbBooks.Select(b => _mapper.Map<GetBookDto>(b)).ToList();
            return serviceResponse;
        }

        public ServiceResponse<GetBookDto> GetBookById(int id)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            serviceResponse.Data = _mapper.Map<GetBookDto>(book);
            return serviceResponse;
        }

        public ServiceResponse<GetBookDto> UpdateBook(UpdateBookDto updatedBook)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == updatedBook.Id);
                if (book == null)
                {
                    throw new Exception($"Book with Id '{updatedBook.Id}' not found!");
                }

                _mapper.Map(updatedBook.Category, book.Category);
                _mapper.Map(updatedBook, book);

                _context.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetBookDto>(book);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
             
            return serviceResponse;
        }
    }
}

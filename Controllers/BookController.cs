using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibSys.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<ServiceResponse<List<GetBookDto>>> GetAll()
        {
            //TODO Current User id
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(_bookService.GetAllBooks());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<GetBookDto>> Get(int id)
        {
            return Ok(_bookService.GetBookById(id));
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult<ServiceResponse<List<GetBookDto>>> AddBook(AddBookDto newBook)
        {
            return Ok(_bookService.AddBook(newBook));
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public ActionResult<ServiceResponse<List<GetBookDto>>> UpdateBook(UpdateBookDto updatedBook)
        {
            var response = _bookService.UpdateBook(updatedBook);
            if (response.Data is null) 
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public ActionResult<ServiceResponse<List<GetBookDto>>> DeleteBook(int id)
        {
            var response = _bookService.DeleteBook(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

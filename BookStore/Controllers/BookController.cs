using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooksByAuthor")]
        public IEnumerable<Book> GetAllBooksByAuthor(int authorId)
        {
            return _bookService.GetAllBooksByAuthor(authorId);
        }
    }
}

using BrynMawrLMS.Models;
using BrynMawrLMS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BrynMawrLMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LMSRepository lmsRepository;

        public BooksController(LMSRepository lmsRepository)
        {
            this.lmsRepository = lmsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = this.lmsRepository.GetAllBooks();

            return Ok(books);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book data is null");

            this.lmsRepository.AddBook(book);
            return Ok(new { message = "Book added successfully." });
        }
    }

}


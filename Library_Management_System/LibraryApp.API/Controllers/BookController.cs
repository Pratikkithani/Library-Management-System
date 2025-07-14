using LibraryApp.Application.Features.BookFeature.Command.AddBook;
using LibraryApp.Application.Features.BookFeature.Command.DeleteBook;
using LibraryApp.Application.Features.BookFeature.Command.UpdateBook;
using LibraryApp.Application.Features.BookFeature.Query.GetAvailableBooks;
using LibraryApp.Application.Features.BookFeature.Query.GetBookById;
using LibraryApp.Application.Features.BookFeature.Query.GetBooks;
using LibraryApp.Application.Features.CategoryFeature.Command.AddCategory;
using LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory;
using LibraryApp.Application.Features.CategoryFeature.Command.UpdateCategory;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategories;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById;
using LibraryApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administartor")]
    public class BookController : ControllerBase
    {
        readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = await _mediator.Send(new GetBooksQuery());
            return Ok(allBooks);
        }

        [AllowAnonymous]
        [HttpGet("getavailbooks")]
        public async Task<IActionResult> GetAvailableBooksAsync()
        {
            var allavailBooks = await _mediator.Send(new GetAvailableBooksQuery());
            return Ok(allavailBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(Book book)
        {
            var result = await _mediator.Send(new AddBookCommand(book));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] Book book)
        {
            var result = await _mediator.Send(new UpdateBookCommand(id, book.Title,book.Author,book.ISBN,book.CategoryId,book.PublishedYear,book.CopiesAvailable));
            return Ok(result);
        }
    }
}

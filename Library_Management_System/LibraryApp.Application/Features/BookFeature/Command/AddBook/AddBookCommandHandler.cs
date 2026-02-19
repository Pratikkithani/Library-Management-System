using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.CategoryFeature.Command.AddCategory;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Command.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        readonly IBookRepository _bookRepository;
        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.AddBookAsync(request.book);
            return book;
        }
    }
}

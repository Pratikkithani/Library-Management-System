using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Features.CategoryFeature.Command.UpdateCategory;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);
            if (book == null)
            {
                throw new NotFoundException($"Book with Id::{request.Id} not found");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.CategoryId = request.categoryid;
            book.PublishedYear = request.published;
            book.CopiesAvailable = request.copiesavail;

            await _bookRepository.UpdateBookAsync(book.BookId, book);
            return true;
        }
    }
}

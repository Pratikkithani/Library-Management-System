using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Command.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookFindStatus = await _bookRepository.GetBookByIdAsync(request.id);
            if (bookFindStatus is null)
            {
                throw new NotFoundException($"Book with Id::{request.id} not found");

            }
            return await _bookRepository.DeleteBookAsync(bookFindStatus.BookId);
        }
    }
}

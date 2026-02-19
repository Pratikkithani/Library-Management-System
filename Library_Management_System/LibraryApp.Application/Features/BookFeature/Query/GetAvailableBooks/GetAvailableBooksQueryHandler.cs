using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.BookFeature.Query.GetBooks;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Query.GetAvailableBooks
{
    public class GetAvailableBooksQueryHandler : IRequestHandler<GetAvailableBooksQuery, IEnumerable<Book>>
    {
        readonly IBookRepository _bookRepository;
        public GetAvailableBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetAvailableBooksQuery request, CancellationToken cancellationToken)
        {
            var allavailBooks = await _bookRepository.GetAvailableBooks();
            return allavailBooks;
        }
    }

}

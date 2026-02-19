using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategories;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Query.GetBooks
{

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var allBooks = await _bookRepository.GetBooks();
            //var books = _mapper.Map<IEnumerable<GetBookDto>>(allBooks);
            return allBooks;
        }
    }
}



    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Query.GetBooks
{
    public record GetBooksQuery : IRequest<IEnumerable<Book>>;

}

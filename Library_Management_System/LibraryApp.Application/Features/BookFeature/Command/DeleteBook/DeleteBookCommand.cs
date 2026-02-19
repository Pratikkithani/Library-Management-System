using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Command.DeleteBook
{
    public record DeleteBookCommand(int id) : IRequest<bool>;

}

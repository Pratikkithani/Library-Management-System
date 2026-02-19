using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryApp.Application.Features.BookFeature.Command.UpdateBook
{
    public record UpdateBookCommand(int Id, string Title, string Author,string ISBN,int categoryid,int published,int copiesavail) : IRequest<bool>;

}

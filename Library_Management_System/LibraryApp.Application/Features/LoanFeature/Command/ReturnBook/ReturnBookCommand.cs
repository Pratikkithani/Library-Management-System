using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Command.ReturnBook
{
        public record ReturnBookCommand(int id) : IRequest<bool>;

}

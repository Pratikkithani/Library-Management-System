using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Models.LoanDto;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Command.BorrowBook
{
        public record BorrowBookCommand(LoanDto loandto,string UserId) : IRequest<Loan>;

}

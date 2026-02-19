using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Query.GetLoansByUserId
{
    public record GetLoansByUserIdQuery(string userId) : IRequest<IEnumerable<Loan>>;

}

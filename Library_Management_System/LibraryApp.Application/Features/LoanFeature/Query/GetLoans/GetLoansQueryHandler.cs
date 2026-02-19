using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategories;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Query.GetLoans
{
    public class GetLoansQueryHandler : IRequestHandler<GetLoansQuery, IEnumerable<Loan>>
    {
        readonly ILoanRepository _loanRepository;
        public GetLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<Loan>> Handle(GetLoansQuery request, CancellationToken cancellationToken)
        {
            var allLoans = await _loanRepository.GetLoans();
            return allLoans;
        }
    }
}

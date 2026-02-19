using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.LoanFeature.Query.GetLoans;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Query.GetLoansByUserId
{
    public class GetLoansByUserIdQueryHandler : IRequestHandler<GetLoansByUserIdQuery, IEnumerable<Loan>>
    {
        readonly ILoanRepository _loanRepository;
        public GetLoansByUserIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<IEnumerable<Loan>> Handle(GetLoansByUserIdQuery request, CancellationToken cancellationToken)
        {
            var allLoans = await _loanRepository.GetLoansByUserIdAsync(request.userId);
            return allLoans;
        }
    }
}

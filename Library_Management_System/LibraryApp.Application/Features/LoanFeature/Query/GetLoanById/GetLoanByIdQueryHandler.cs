using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Query.GetLoanById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, Loan>
    {
        readonly ILoanRepository _loanRepository;
        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Loan> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loanFindStatus = await _loanRepository.GetLoanByIdAsync(request.id);
            return loanFindStatus;
        }
    }
}

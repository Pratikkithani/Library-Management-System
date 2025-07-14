using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Command.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, bool>
    {
        readonly ILoanRepository _loanRepository;
        public ReturnBookCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<bool> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var loanFindStatus = await _loanRepository.GetLoanByIdAsync(request.id);
            if (loanFindStatus is null)
            {
                throw new NotFoundException($"Loan with Id::{request.id} not found");

            }
            return await _loanRepository.ReturnBookAsync(loanFindStatus.LoanId);
        }
    }
}

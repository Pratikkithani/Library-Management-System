using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.LoanFeature.Query.GetLoanById;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Application.Interfaces.MemberInterfaces;
using LibraryApp.Application.Models.LoanDto;
using LibraryApp.Domain;
using MediatR;

namespace LibraryApp.Application.Features.LoanFeature.Command.BorrowBook
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, Loan>

    {
        readonly ILoanRepository _loanRepository;
        readonly IMemberRepository _memberRepository;
        public BorrowBookCommandHandler(ILoanRepository loanRepository,IMemberRepository memberRepository)
        {
            _loanRepository = loanRepository;
            _memberRepository = memberRepository;
        }

        public async Task<Loan> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var memberData = await _memberRepository.GetMemberByUserId(request.UserId);
            if (memberData == null)
            {
                return null;
            }

            var loan = new Loan()
            {
                BookId = request.loandto.BookId,
                MemberId = memberData.MemberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10),
                Status = "Borrowed"
            };
            var loanResponse = await _loanRepository.BorrowBookAsync(loan);
            return loanResponse;
        }
    }
}

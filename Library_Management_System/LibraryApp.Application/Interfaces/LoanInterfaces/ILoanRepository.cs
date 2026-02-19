using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain;

namespace LibraryApp.Application.Interfaces.LoanInterfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetLoans();
        Task<IEnumerable<Loan>> GetLoansByUserIdAsync(string userId);
        Task<Loan> GetLoanByIdAsync(int id);
        Task<Loan> BorrowBookAsync(Loan loan);
        Task<bool> ReturnBookAsync(int loanId);
    }
}

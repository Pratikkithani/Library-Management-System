using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class LoanRepository : ILoanRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;
        public LoanRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task<Loan> BorrowBookAsync(Loan loan)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.BookId == loan.BookId);
            if (book == null)
            {
                return null;
            }
            book.CopiesAvailable = book.CopiesAvailable - 1;
            await _libraryDbContext.AddAsync(loan);
            await Task.Run(() => _libraryDbContext.Books.Update(book));
            await _libraryDbContext.SaveChangesAsync();

            return loan;
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _libraryDbContext.Loans.FirstOrDefaultAsync(b => b.LoanId == id);

        }

        public async Task<IEnumerable<Loan>> GetLoans()
        {
            return await _libraryDbContext.Loans.Include(b=>b.Book).ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansByUserIdAsync(string userId)
        {
            return await _libraryDbContext.Loans.Include(u=>u.Member).Include(u => u.Book).Where(b=>b.Member.UserId==userId).ToListAsync();
        }

        public async Task<bool> ReturnBookAsync(int loanId)
        {
            var loan = await GetLoanByIdAsync(loanId);
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.BookId == loan.BookId);
            book.CopiesAvailable = book.CopiesAvailable + 1;
            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;
            if (loan is not null)
            {
                _libraryDbContext.Loans.Update(loan);
                await Task.Run(() => _libraryDbContext.Books.Update(book));
                return await _libraryDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }


    }
}

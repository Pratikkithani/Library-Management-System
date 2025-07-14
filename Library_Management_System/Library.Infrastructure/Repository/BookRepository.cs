using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            await _libraryDbContext.Books.AddAsync(book);
            await _libraryDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if (book is not null)
            {
                _libraryDbContext.Books.Remove(book);
                return await _libraryDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _libraryDbContext.Books.Include(c=>c.Category).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _libraryDbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            var result = await GetBookByIdAsync(id);
            if (result is not null)
            {
                _libraryDbContext.Books.Update(book);
                return await _libraryDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetAvailableBooks()
        {
            return await _libraryDbContext.Books
            .Where(b => b.CopiesAvailable > 0)
            .ToListAsync();
        }
    }
}

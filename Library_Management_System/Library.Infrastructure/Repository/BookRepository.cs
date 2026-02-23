using Dapper;
using Library.Infrastructure.Context;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        protected readonly LibraryDbContext _libraryDbContext;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration, LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LibraryWebAPIconnString");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
        //public async Task<Book> AddBookAsync(Book book)
        //{
        //    await _libraryDbContext.Books.AddAsync(book);
        //    await _libraryDbContext.SaveChangesAsync();
        //    return book;
        //}

        public async Task<Book> AddBookAsync(Book book)
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Title", book.Title);
            parameters.Add("@Author", book.Author);
            parameters.Add("@CategoryId", book.CategoryId);
            parameters.Add("@CopiesAvailable", book.CopiesAvailable);
            parameters.Add("@ISBN", book.ISBN);
            parameters.Add("@PublishedYear", book.PublishedYear);

            var bookId = await connection.QuerySingleAsync<int>(
                "sp_AddBook",
                parameters,
                commandType: CommandType.StoredProcedure);

            book.BookId = bookId;
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

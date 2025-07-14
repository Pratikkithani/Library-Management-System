using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Dtos.BookDto;
using LibraryApp.Domain;

namespace LibraryApp.Application.Interfaces.BookInterfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetAvailableBooks();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(int categoryId, Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorAPI.DataAccess.Data
{
    public interface IBookReader
    {
        Task<Book> AddBook(Book book);
        Task DeleteBook(int isbn);
        Task<IList<Book>> getAllBooksAsync();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorAPI.DataAccess.Data
{
    public interface IBookReader
    {
        Task<Book> AddBook(Book book);
        Task<IList<Book>> getAllBooksAsync();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;


namespace AuthorAPI.DataAccess.Data
{
    public interface IBookReader
    {
        Task<Book> AddBook(Book book, int id);
        Task DeleteBook(int isbn);
        // Task<IList<Book>> getAllBooksAsync();
    }
}
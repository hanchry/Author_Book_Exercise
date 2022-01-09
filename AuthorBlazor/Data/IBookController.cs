using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace AuthorBlazor.Data
{
    public interface IBookController
    {
        Task<List<Book>> GetBook();
        Task DeleteBook(Book book);
        Task AddBook(Book book, int id);
    }
}
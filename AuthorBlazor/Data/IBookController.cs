using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorBlazor.Data
{
    public interface IBookController
    {
        Task<List<Book>> GetBook();
        Task DeleteBook(Book book);
        Task AddBook(Book book);
    }
}
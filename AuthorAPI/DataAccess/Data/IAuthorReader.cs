using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorAPI.DataAccess.Data
{
    public interface IAuthorReader
    {
        Task<Author> AddAuthor(Author author);
        Task<IList<Author>> getAllAuthorsAsync();
    }
}
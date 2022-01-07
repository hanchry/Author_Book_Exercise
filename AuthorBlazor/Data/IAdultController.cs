using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorBlazor.Data
{
    public interface IAdultController
    {
        Task AddAuthor(Author author);
        Task<List<Author>> GetAuthor();
    }
}
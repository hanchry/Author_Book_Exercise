using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace AuthorBlazor.Data
{
    public interface IAdultController
    {
        Task AddAuthor(Author author);
        Task<List<Author>> GetAuthor();
    }
}
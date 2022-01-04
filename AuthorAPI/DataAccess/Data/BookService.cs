using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.DataAccess.Database;
using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DataAccess.Data
{
    public class BookService:IBookReader
    {
        private AuthorDBContext Context;

        public BookService(AuthorDBContext context)
        {
            Context = context;
        }
        public async Task<Book> AddBook(Book book)
        {
            Context.Books.Add(book);
            await Context.SaveChangesAsync();
            return book;
        }

        public async Task<IList<Book>> getAllBooksAsync()
        {
            return await Context.Books.ToListAsync();
        }
    }
}
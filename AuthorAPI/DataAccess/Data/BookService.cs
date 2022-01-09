using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Model;

namespace AuthorAPI.DataAccess.Data
{
    public class BookService:IBookReader
    {
        private AuthorDBContext Context;

        public BookService(AuthorDBContext context)
        {
            Context = context;
        }
        public async Task<Book> AddBook(Book book, int id)
        {
            Context.Authors.FirstOrDefault(c => c.Id == 1).Books.Add(book);
            Context.Books.Add(book);
            await Context.SaveChangesAsync();
            return book;
        }
        public async Task DeleteBook(int isbn)
        {
            Book book = Context.Books.FirstOrDefault(t => t.ISBN == isbn);
            Context.Books.Remove(book);
            await Context.SaveChangesAsync();
        }
        
    }
}
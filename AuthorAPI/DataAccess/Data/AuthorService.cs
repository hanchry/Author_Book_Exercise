using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Model;

namespace AuthorAPI.DataAccess.Data
{
    public class AuthorService:IAuthorReader
    {
        private AuthorDBContext Context;

        public AuthorService(AuthorDBContext authorDbContext)
        {
            Context = authorDbContext;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            Context.Authors.Add(author);
            await Context.SaveChangesAsync();
            return author;
        }

        public async Task<IList<Author>> getAllAuthorsAsync()
        {
            return await Context.Authors.Include(t=>t.Books).ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.DataAccess.Data;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class BookController: ControllerBase
        {
            private IBookReader bookReader;

            public BookController(IBookReader bookReader)
            {
                this.bookReader = bookReader;
            }

            [HttpPost]
            public async Task<ActionResult<Book>> addBook([FromBody] Book book)
            {
                try
                {
                    Book added = bookReader.AddBook(book).Result;
                    return Created($"/{added.ISBN}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            public async Task<ActionResult<IList<Book>>> getAuthors()
            {
                try
                {
                    IList<Book> books = bookReader.getAllBooksAsync().Result;
                    return Ok(books);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e);
                }
            }
            [HttpDelete]
            [Route("{isbn}")]
            public async Task<ActionResult> deleteBook([FromRoute] int isbn)
            {
                Console.WriteLine("deleteBook");
                try
                {
                    Console.WriteLine("deleteBook");
                    await bookReader.DeleteBook(isbn);
                    Console.WriteLine("deleteBook");
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }
            
        }
}
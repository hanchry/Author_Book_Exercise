using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.DataAccess.Data;
using AuthorAPI.DataAccess.Database;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController: ControllerBase
    {
        private IAuthorReader authorReader;

        public AuthorController(IAuthorReader authorReader)
        {
            this.authorReader = authorReader;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> addAuthor([FromBody] Author author)
        {
            try
            {
                Author added = authorReader.AddAuthor(author).Result;
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> getAuthors()
        {
            try
            {
                IList<Author> authors = authorReader.getAllAuthorsAsync().Result;
                return Ok(authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e);
            }
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace AuthorBlazor.Data
{
    public class BookReader:IBookController
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;

        public BookReader()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }
        
        public async Task<List<Book>> GetBook()
        {
            List<Book> books = new List<Book>();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Book");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            books = JsonConvert.DeserializeObject<List<Book>>(reply);
            return books;
        }

        public async Task DeleteBook(Book book)
        {
            Console.WriteLine("DeleteBook");
            await client.DeleteAsync(uri + $"/Book/{book.ISBN}");
            Console.WriteLine("DeleteBook");
        }

        public async Task AddBook(Book book, int id)
        {
            string serialized = JsonConvert.SerializeObject(book);
            StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Book/{id}", content);
        }
    }
}
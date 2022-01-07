using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuthorAPI.Models;
using Newtonsoft.Json;

namespace AuthorBlazor.Data
{
    public class AdultReader:IAdultController 
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;

        public AdultReader()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }   
        
        public async Task AddAuthor(Author author)
        {
            string serialized = JsonConvert.SerializeObject(author);
            StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Author", content);
        }

        public async Task<List<Author>> GetAuthor()
        {
            List<Author> authors = new List<Author>();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Author");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            authors = JsonConvert.DeserializeObject<List<Author>>(reply);
            return authors;
        }
    }
}
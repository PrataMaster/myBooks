using myBooks.Models;
using myBooks.ViewModels.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myBooks.Views.Services
{
    public class AppService : IAppService
    {
        private HttpClient client;
        private readonly string booksRequestUri = "https://localhost:44326/api/Livros";

        public AppService()
        {
            client = new HttpClient();
        }

        #region BooksRequest
        public async Task<List<Livro>> GetBooks()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(booksRequestUri);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                List<Livro> livros = JsonConvert.DeserializeObject<List<Livro>>(content);
                return livros;
            }
            return null;
        }

        public async Task<Livro> GetBookById(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(booksRequestUri + id.ToString());

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                Livro livro = JsonConvert.DeserializeObject<Livro>(content);
                return livro;
            }
            return null;
        }


        public async Task PostBook(Usuario usuario, Livro livro)
        {
            Livro _livro = new Livro()
            {
                BookImgName = livro.BookImgName,
                BookImgVb = livro.BookImgVb,
                Title = livro.Title,
                Year = livro.Year,
                Publisher = livro.Publisher,
                Genre = livro.Genre,
                UserId = usuario.UserId
            };

            string livroJson = JsonConvert.SerializeObject(_livro);

            HttpContent httpContent = new StringContent(livroJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(booksRequestUri, httpContent).Result;

            responseMessage.EnsureSuccessStatusCode();

            string json = await responseMessage.Content.ReadAsStringAsync();
        }

        public Task PutBook()
        {
            throw new NotImplementedException();
        }
        public Task DeleteBook()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
